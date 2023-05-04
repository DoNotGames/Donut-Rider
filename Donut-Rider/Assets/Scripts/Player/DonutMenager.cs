using System.Collections.Generic;
using UnityEngine;

public class DonutMenager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float friction;
    [SerializeField] private float midAirFriction;
    [SerializeField] private float speed;
    [SerializeField] private float accelerationForce;
    [SerializeField] private float slowForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minimalSpeed;

    [Header("Damage")]
    [SerializeField] private float invulnerableTimeAfterDamage;
    [SerializeField] private List<GameObject> sprinkles;

    public DonutHealth donutHealth { get; private set; }
    public bool isInvulnerable { get; set; }

    private float timePast;
    private DonutMovement donutMovement;
    private DonutEffects donutEffects;

    private Rigidbody donutRigidbody;
    private bool isBreaking;

    private void Awake()
    {
        donutMovement = GetComponent<DonutMovement>();
        donutMovement.ChangeMoveForce(speed);
        donutMovement.SetGroundFricition(friction);
        donutMovement.SetMidAirFricition(midAirFriction);
        donutHealth = new DonutHealth(this);
        donutEffects = new DonutEffects(transform.Find("VFX").gameObject);
        donutRigidbody = GetComponent<Rigidbody>();
        donutRigidbody.drag = friction;
    }

    private void Update()
    {
        Stayinvulnerable();
        SpeedControll();
    }

    public void Thrust()
    {
        donutMovement.ChangeMoveForce(speed + accelerationForce);
    }

    public void EndThrust()
    {
        donutMovement.ChangeMoveForce(speed);
    }

    public void Brake()
    {
        isBreaking = true;
        donutMovement.ChangeMoveForce(speed - slowForce);
    }

    public void EndBrake()
    {
        isBreaking = false;
        donutMovement.ChangeMoveForce(speed);
    }

    public void Jump()
    {
        donutMovement.Jump(jumpForce);
    }

    public void SlowDown(float slowForce)
    {
        if (isInvulnerable)
            return;

        donutMovement.AddForce(new Vector3(-slowForce, 0));
    }

    public void EjectSprinkles()
    {
        donutEffects.EjectSprinkles(sprinkles[0].transform);
        sprinkles.Remove(sprinkles[0]);
    }

    private void Stayinvulnerable()
    {
        if (!isInvulnerable)
            return;

        timePast += Time.deltaTime;
        donutEffects.Flicker();

        if (timePast >= invulnerableTimeAfterDamage)
        {
            isInvulnerable = false;
            donutEffects.ShowVFX();
            timePast = 0;
        }
    }

    private void SpeedControll()
    {
        if (isBreaking)
        {
            if (donutRigidbody.velocity.x <= minimalSpeed)
            {
                donutMovement.ChangeMoveForce(speed);
                return;
            }

            donutMovement.ChangeMoveForce(speed - slowForce);
        }
    }
}
