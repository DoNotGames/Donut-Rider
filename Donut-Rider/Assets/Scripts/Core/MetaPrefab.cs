using System;
using UnityEngine;

public class MetaPrefab : MonoBehaviour
{
    public GameObject EndEffects;
    public Action EndGameByMetaEvent;


    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<DonutMenager>())
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
        player.SetActive(false);
    }

    public void StartEndEffect()
    {
        var effects = Instantiate(EndEffects, gameObject.transform.position,Quaternion.identity);
        Destroy(effects, 5f);
    }
}
