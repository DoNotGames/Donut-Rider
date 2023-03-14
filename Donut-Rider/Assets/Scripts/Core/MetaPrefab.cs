using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPrefab : MonoBehaviour
{
    public GameObject EndEffects;
    public delegate void EndGame();
    public static event EndGame EndGameByMetaEvent;


    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Donut>())
        {
            EndGameByMeta(collider.gameObject);
        }
    }

    public void EndGameByMeta(GameObject player)
    {
        EndGameByMetaEvent?.Invoke();
        int currLvlIndex = PlayerPrefs.GetInt("NextLevelUnlockIndex");
        PlayerPrefs.SetInt("NextLevelUnlockIndex", currLvlIndex + 1);
        StartEndEffect();
       //ameStatus.CurrentGameStatus = GameStatus.CurrentGameStatus.Play;
        player.SetActive(false);
    }

    public void StartEndEffect()
    {
        var effects = Instantiate(EndEffects, gameObject.transform.position,Quaternion.identity);
        Destroy(effects, 5f);
    }
}
