using Mono.Cecil;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.02f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float thrustMaxSpeed = 20f;
    [SerializeField] private float thrustForce = 2.7f;
    [SerializeField] private float brakePower = 10f;
    [SerializeField] private Vector3 slowDownForce = new Vector3(0.8f, 0f, 0f);
    [SerializeField] private float jumpForce = 40f;
    [SerializeField] private float bufferCheckDistance = 0.1f;

    private Vector3 constantForceBase;
    private Vector3 thrustForceToAdd;
    private bool brake = false;
    private bool grounded = false;
    private float groundCheckDistance;

    private Rigidbody donutRigidbody = null;
    private ConstantForce constantForceComponent = null;
    private Donut donut = null;


    private void Awake()
    {
        donutRigidbody = GetComponent<Rigidbody>();
        if (donutRigidbody == null)
        {
            Debug.LogWarning("DonutRigidbody is not valid");
            return;
        }

        constantForceComponent = GetComponent<ConstantForce>();
        if (constantForceComponent == null)
        {
            Debug.LogWarning("ConstantForce is not valid");
            return;
        }

        donut = GetComponent<Donut>();
        if (donut == null)
        {
            Debug.LogWarning("Donut is not valid");
            return;
        }

        constantForceBase = constantForceComponent.force;

        groundCheckDistance = GetComponent<SphereCollider>().radius + bufferCheckDistance;
    }

    private void Update()
    {
        if (donutRigidbody.velocity.magnitude <= minSpeed)
        {
            donut.GameOver();
        }

        RaycastHit hit;
        grounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance);
    }

    private void FixedUpdate()
    {
        if (!grounded)
            return;

        if(brake)
        {
            donutRigidbody.velocity = new Vector3(Mathf.MoveTowards(donutRigidbody.velocity.x, 0f, brakePower * Time.deltaTime), donutRigidbody.velocity.y, donutRigidbody.velocity.z);
            return;
        }

        if (thrustForceToAdd != Vector3.zero)
        {
            donutRigidbody.AddForce(thrustForceToAdd);

            if (donutRigidbody.velocity.x > thrustMaxSpeed)
            {
                donutRigidbody.velocity = donutRigidbody.velocity.normalized * thrustMaxSpeed;
            }
            return;
        }

        if (donutRigidbody.velocity.x > maxSpeed)
        {
            constantForceComponent.force = slowDownForce;
            return;
        }

        constantForceComponent.force = constantForceBase;
    }

    public void Thrust()
    {
        thrustForceToAdd += Vector3.right * thrustForce;
    }

    public void EndThrust()
    {
        thrustForceToAdd = Vector3.zero;
    }

    public void Brake()
    {
        brake = true;
        constantForceComponent.force = Vector3.zero;
    }

    public void EndBrake()
    {
        brake = false;
        constantForceComponent.force = constantForceBase;
    }

    public void Jump()
    {
        if (!grounded) return;

        donutRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
