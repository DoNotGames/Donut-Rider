using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Vector3 offset = Vector3.zero;

    private GameObject objectToFollow;

    public void Init(GameObject obj)
    {
        objectToFollow = obj;
        enabled = true;
    }

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
