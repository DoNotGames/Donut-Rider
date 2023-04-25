using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float slowDownForce;
    [SerializeField] private int damage;

    [SerializeField] private bool isDamaging;
    [SerializeField] private bool isSlowingDown;
    private void OnTriggerEnter(Collider other)
    {
        React(other.GetComponent<Donut>());
    }

    public void React(Donut donut)
    {
        if (isDamaging)
            donut.TakeDamage(damage);

        if (isSlowingDown)
            donut.SlowDown(slowDownForce);
    }
}
