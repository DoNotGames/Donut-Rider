using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.02f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float thrustMaxSpeed = 20f;
    [SerializeField] private float thrustForce = 2.7f;
    [SerializeField] private float brakePower = 4f;
    [SerializeField] private Vector3 slowDownForce = new Vector3(0.8f, 0f, 0f);

    private float dragBase;
    private Vector3 constantForceBase;
    private Vector3 thrustForceToAdd;

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

        dragBase = donutRigidbody.drag;
        constantForceBase = constantForceComponent.force;
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
        if (thrustForceToAdd != Vector3.zero)
        {
            donutRigidbody.AddForce(thrustForceToAdd);

            if (donutRigidbody.velocity.magnitude > thrustMaxSpeed)
            {
                donutRigidbody.velocity = donutRigidbody.velocity.normalized * thrustMaxSpeed;
            }
            return;
        }

        if (donutRigidbody.velocity.magnitude > maxSpeed)
        {
            constantForceComponent.force = slowDownForce;//Vector3.zero;
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
