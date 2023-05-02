using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
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
        Vector3 desiredPosition = playerTransform.position + cameraOffset;
        mainCameraTransform.position = Vector3.Slerp(mainCameraTransform.position, desiredPosition, Time.deltaTime * cameraSpeed);
    }
}
