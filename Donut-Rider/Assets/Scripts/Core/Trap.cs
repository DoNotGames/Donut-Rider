using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float slowDownForce;
    [SerializeField] private int damage;

    [SerializeField] private bool isDamaging;
    [SerializeField] private bool isSlowingDown;
    private void OnTriggerEnter(Collider other)
    {
        React(other.GetComponent<DonutMenager>());
    }

    public void React(DonutMenager donutMenager)
    {
        if (isDamaging)
            donutMenager.donutHealth.TakeDamage(damage);

        if (isSlowingDown)
            donutMenager.SlowDown(slowDownForce);
    }
}
