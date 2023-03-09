using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    [SerializeField] public static DonutController Instance;
    [SerializeField] private Rigidbody DonutRigidbody;
    [SerializeField] private bool MoveRight = false;
    [SerializeField] private bool MoveLeft = false;
    [SerializeField] public bool CanMove = true;
    [SerializeField] private float DonutSpeed = 2f;

    private void Awake()
    {
        DonutRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) //Strefe left
        {
            MoveLeft = true;
        } else { MoveLeft = false; }
        if (Input.GetKey(KeyCode.D)) //Strefe right
        {
            MoveRight = true;
        }
        else { MoveRight = false; }
    }

    private void FixedUpdate()
    {
        if (MoveLeft == true && CanMove == true)
        {
            DonutRigidbody.AddForce(-transform.right * DonutSpeed * Time.fixedDeltaTime * 50f, ForceMode.Acceleration);
            Debug.Log("Left");
        }
        if (MoveRight == true && CanMove == true)
        {
            DonutRigidbody.AddForce(transform.right * DonutSpeed * Time.fixedDeltaTime * 50f, ForceMode.Acceleration);
            Debug.Log("Right");
        }
    }
}
