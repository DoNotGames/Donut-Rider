using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        React(other.GetComponent<Donut>());
    }

    public abstract void React(Donut donut);
}
