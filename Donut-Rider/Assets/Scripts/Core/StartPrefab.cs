using UnityEngine;

public class StartPrefab : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GrayscaleFilterPrefab;

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
        var Player = Instantiate(PlayerPrefab, spawnPos, Quaternion.identity);
        //var Filter = Instantiate(GrayscaleFilterPrefab, spawnPos, Quaternion.identity);

        //Filter.GetComponent<Follower>().Init(Player);
    }
}
