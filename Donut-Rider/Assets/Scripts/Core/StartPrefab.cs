using UnityEngine;

public class StartPrefab : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GrayscaleFilterPrefab;
    public GameObject PointToCaptureInViewport;

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnEnable()
    {
        SpawnPlayer(gameObject.transform.position);
    }

    public void SpawnPlayer(Vector3 spawnPos)
    {
        var Player = Instantiate(PlayerPrefab, spawnPos, Quaternion.identity);

        var Point = Instantiate(PointToCaptureInViewport, spawnPos, Quaternion.identity);
        Point.GetComponent<Follower>().Init(Player);

        var Filter = Instantiate(GrayscaleFilterPrefab, Vector3.zero, Quaternion.identity, FindObjectOfType<Canvas>().transform);
        Filter.GetComponent<GrayscaleFilter>().Init(Point);
    }
}
