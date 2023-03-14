using Mono.Cecil;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.02f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float thrustMaxSpeed = 20f;
    [SerializeField] private float thrustForce = 2.7f;
    [SerializeField] private float brakePower = 4f;
    [SerializeField] private Vector3 slowDownForce = new Vector3(0.8f, 0f, 0f);
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private LayerMask platformLayerMask;

    private float dragBase;
    private Vector3 constantForceBase;
    private Vector3 thrustForceToAdd;
    private bool brake = false;

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
        float desiredSpeed = brake ? 0f : maxSpeed;

        donutRigidbody.velocity = new Vector3(Mathf.MoveTowards(donutRigidbody.velocity.magnitude, desiredSpeed, 5f * Time.deltaTime), donutRigidbody.velocity.y, donutRigidbody.velocity.z);


        //if (thrustForceToAdd != Vector3.zero)
        //{
        //    donutRigidbody.AddForce(thrustForceToAdd);

        //    if (donutRigidbody.velocity.magnitude > thrustMaxSpeed)
        //    {
        //        donutRigidbody.velocity = donutRigidbody.velocity.normalized * thrustMaxSpeed;
        //    }
        //    return;
        //}

        //if (donutRigidbody.velocity.magnitude > maxSpeed)
        //{
        //    constantForceComponent.force = slowDownForce;//Vector3.zero;
        //    return;
        //}
        //constantForceComponent.force = constantForceBase;
    }

    public void Thrust()
    {
        // thrustForceToAdd += Vector3.right * thrustForce;
        maxSpeed = 20f;
    }

    public void EndThrust()
    {
        //thrustForceToAdd = Vector3.zero;
        maxSpeed = 10f;
    }

    public void Brake(bool pressed)
    {
        if (pressed)
        {
            brake = true;
            //donutRigidbody.drag = brakePower;
            return;
        }
        brake = false;
        //donutRigidbody.drag = dragBase;
    }

    public void Jump()
    {
        if (IsGrounded()) Debug.Log("Grounded");
        if (!IsGrounded()) Debug.Log("Air");
        if (!IsGrounded()) return;

        donutRigidbody.AddForce(Vector3.up * jumpForce);
    }

    public bool IsGrounded()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        RaycastHit raycastHit;

        return Physics.SphereCast(sphereCollider.bounds.center, sphereCollider.radius + 2f, -transform.up, out raycastHit, 2f, platformLayerMask);
    }
}
