using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField][Range(0,20)] private float cameraDelay;
    [SerializeField] private Vector3 cameraOffset;

    private Transform playerTransform;
    private Transform mainCameraTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPositon = playerTransform.position + cameraOffset;
        mainCameraTransform.position = Vector3.Slerp(mainCameraTransform.position, desiredPositon, Time.deltaTime * cameraDelay);
    }
}
