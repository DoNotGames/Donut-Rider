using UnityEngine;

public class DonutMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded;
    private float groundCheckDistance;
    private float force;
    private float groundDrag;
    private float midAirDrag;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        groundCheckDistance = GetComponent<SphereCollider>().radius;
    }

    private void FixedUpdate()
    {
        grounded = CheckForGrounded();

        if (!grounded)
            return;

        Vector3 currentForce = new Vector3(force, 0);
        rb.AddForce(Vector3.right + currentForce);

    }

    public void SetGroundFricition(float groundDrag) => this.groundDrag = groundDrag;
    public void SetMidAirFricition(float midAirDrag) => this.midAirDrag = midAirDrag;

    public void ChangeMoveForce(float speed)
    {
        force = speed;
    }

    public void Jump(float jumpForce)
    {
        if (!grounded)
            return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void AddForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Impulse);
    }

    private bool CheckForGrounded()
    {
        bool isGrounded = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance + 0.1f))
            isGrounded = true;

        if (Physics.Raycast(transform.position, (Vector3.down + Vector3.right).normalized, out hit, groundCheckDistance + 0.1f))
            isGrounded = true;

        SetDrag(isGrounded);

        return isGrounded;
    }

    private void SetDrag(bool isGrounded)
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
            return;
        }

        rb.drag = midAirDrag;
    }
}
