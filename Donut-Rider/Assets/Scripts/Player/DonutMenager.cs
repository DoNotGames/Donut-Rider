using System.Collections.Generic;
using UnityEngine;

public class DonutMenager : MonoBehaviour
{
    [SerializeField] private float friction;
    [SerializeField] private float speed;
    [SerializeField] private float accelerationForce;
    [SerializeField] private float slowForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float invulnerableTimeAfterDamage;
    [SerializeField] private List<GameObject> sprinkles;

    public DonutHealth donutHealth { get; private set; }
    public bool isInvulnerable { get; set; }

    private float timePast;
    private DonutMovement donutMovement;
    private DonutEffects donutEffects;

    private void Awake()
    {
        donutMovement = GetComponent<DonutMovement>();
        donutMovement.ChangeSpeed(speed);
        donutHealth = new DonutHealth(this);
        donutEffects = new DonutEffects(transform.Find("VFX").gameObject);
        GetComponent<Rigidbody>().drag = friction;
    }

    private void Update()
    {
        Stayinvulnerable();
    }

    public void Thrust()
    {
        donutMovement.ChangeSpeed(speed + accelerationForce);
    }

    public void EndThrust()
    {
        donutMovement.ChangeSpeed(speed);
    }

    public void Brake()
    {
        donutMovement.ChangeSpeed(speed - slowForce);
    }

    public void EndBrake()
    {
        donutMovement.ChangeSpeed(speed);
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

    public void EjectSprinkles()
    {
        donutEffects.EjectSprinkles(sprinkles[0].transform);
        sprinkles.Remove(sprinkles[0]);
    }
}
