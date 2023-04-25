using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    [SerializeField] private List<GameObject> sprinkles;
    [SerializeField] private bool isInvulnerable;
    [SerializeField] private float invulnerableTimeAfterDamage;

    public delegate void OnGameOver();
    public event OnGameOver onGameOver;

    public delegate void OnLevelComplete();
    public event OnLevelComplete onLevelComplete;

    private GameObject vfx;

    private HPComponent hpComponent;
    private DonutController donutController;

    private float timePast;

    private void Awake()
    {
        hpComponent = GetComponent<HPComponent>();
        if(hpComponent == null) 
        {
            Debug.LogWarning("HPComponent is not valid");
            return;
        }

        donutController = GetComponent<DonutController>();
        vfx = transform.Find("VFX").gameObject;
    }

    private void Update()
    {
        Stayinvulnerable();
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
        onGameOver?.Invoke();
    }

    public void LevelComplete()
    {
        Debug.Log("Level completed!");
        onLevelComplete?.Invoke();
    }

    public void TakeDamage(int damage = 1)
    {
        if (isInvulnerable)
            return;

        hpComponent.HP -= damage;
        isInvulnerable = true;
        //on damage taken
    }

    public void SlowDown(float slowForce)
    {
        if (isInvulnerable)
            return;

        donutController.ReduceSpeed(slowForce);
    }

    private void Stayinvulnerable()
    {
        if (!isInvulnerable)
            return;

        timePast += Time.deltaTime;
        Flicker();

        if (timePast >= invulnerableTimeAfterDamage)
        {
            isInvulnerable = false;
            vfx.SetActive(true);
            timePast = 0;
        }
    }

    private void Flicker()
    {
        if (Time.fixedTime % .2 < .1)
        {
            vfx.SetActive(false);
            return;
        }

        vfx.SetActive(true);
    }
}
