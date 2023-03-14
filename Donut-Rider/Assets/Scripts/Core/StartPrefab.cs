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
        Instantiate(PlayerPrefab, spawnPos, Quaternion.identity);
    }
}
