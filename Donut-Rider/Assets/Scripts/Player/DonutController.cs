using UnityEngine;
using UnityEngine.InputSystem;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float brakePower;

    private Rigidbody donutRigidbody;
    private Vector3 force;
    private float dragBase;

    DonutController()
    {
        speed = 1f;
        donutRigidbody = null;
        force = Vector3.zero;
    }

    private void Awake()
    {
        donutRigidbody = GetComponent<Rigidbody>();
        dragBase = donutRigidbody.drag;
    }

    private void FixedUpdate()
    {
        if (force != Vector3.zero)
        {
            donutRigidbody.AddForce(force);
        }
    }

    public void Thrust(InputAction.CallbackContext context)
    {
        force = Vector3.zero;
        force += Vector3.right * context.ReadValue<float>() * speed;
    }

    public void Brake(InputAction.CallbackContext context)
    {
        switch(context.phase)
        {
            case InputActionPhase.Started:
                {
                    donutRigidbody.drag = brakePower;
                    break;
                }

            case InputActionPhase.Canceled:
                {
                    donutRigidbody.drag = dragBase;
                    break;
                }
        }
    }
}
