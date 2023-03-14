using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrefab : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnEnable()
    {
        SpawnPlayer(gameObject.transform.position, PlayerPrefab);
    }

    public void SpawnPlayer(Vector3 spawnPos, GameObject playerPrefab)
    {
        Instantiate(PlayerPrefab, spawnPos, new Quaternion(0, 90, 90, 0));
    }
}
