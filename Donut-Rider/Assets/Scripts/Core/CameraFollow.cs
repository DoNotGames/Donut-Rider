using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float cameraDelay;

    private Transform playerTransform;
    private Transform mainCameraTransform;
    private Vector3 cameraOffset;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCameraTransform = Camera.main.transform;
        cameraOffset = mainCameraTransform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 desiredPositon = playerTransform.position + cameraOffset;
        desiredPositon = new Vector3(desiredPositon.x, desiredPositon.y, mainCameraTransform.position.z);
        mainCameraTransform.position = Vector3.Slerp(mainCameraTransform.position, desiredPositon, Time.deltaTime * cameraDelay);
    }
}
