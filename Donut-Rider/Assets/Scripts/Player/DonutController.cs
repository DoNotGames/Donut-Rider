using UnityEngine;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float brakePower;
    [SerializeField] private float minSpeed;

    private Rigidbody donutRigidbody;
    private Vector3 force;
    private float dragBase;

    private Donut donut;

    private void Awake()
    {
        speed = 1f;
        brakePower = 4f;
        minSpeed = 0.02f;
        donutRigidbody = null;
        force = Vector3.zero;

        donutRigidbody = GetComponent<Rigidbody>();
        if (donutRigidbody == null)
        {
            Debug.LogWarning("DonutRigidbody is not valid");
        }

        dragBase = donutRigidbody.drag;
        donutRigidbody.AddForce(Vector3.right * speed);

        donut = GetComponent<Donut>();
        if (donut == null)
        {
            Debug.LogWarning("Donut is not valid");
        }

        force += Vector3.right * speed;
    }

    private void Update()
    {
        if (donutRigidbody.velocity.magnitude <= minSpeed)
        {
            donut.GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (force != Vector3.zero)
        {
            donutRigidbody.AddForce(force);
        }
    }

    public void Thrust()
    {
        force = Vector3.zero;
        force += Vector3.right * speed;
    }

    public void Brake(bool pressed)
    {
        if (pressed)
        {
            donutRigidbody.drag = brakePower;
            return;
        }

        donutRigidbody.drag = dragBase;
    }
}
