using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPrefab : MonoBehaviour
{
    public GameObject EndEffects;
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
        Destroy(player);
        int currLvlIndex = PlayerPrefs.GetInt("NextLevelUnlockIndex");
        PlayerPrefs.SetInt("NextLevelUnlockIndex", currLvlIndex + 1);
        StartEndEffect();
    }

    public void StartEndEffect()
    {
        var effects = Instantiate(EndEffects, gameObject.transform.position,Quaternion.identity);
        Destroy(effects, 5f);
    }
}
