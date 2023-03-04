using UnityEngine;

public class Donut : MonoBehaviour
{
    private HPComponent hpComponent;
    private DonutController donutController;

    public delegate void OnGameOver();
    public event OnGameOver onGameOver;

    public delegate void OnLevelComplete();
    public event OnLevelComplete onLevelComplete;

    Donut()
    {
        hpComponent = null;
        donutController = null;
    }

    private void Awake()
    {
        hpComponent = GetComponent<HPComponent>();
        if(hpComponent == null) 
        {
            Debug.LogWarning("HPComponent is not valid");
        }

        donutController = GetComponent<DonutController>();
        if (donutController == null)
        {
            Debug.LogWarning("DonutController is not valid");
        }
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
        hpComponent.HP -= damage;
        //on damage taken
    }
}
