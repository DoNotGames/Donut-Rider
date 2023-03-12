using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        Donut donut = other.GetComponent<Donut>();

        React(donut);
    }

    public virtual void React(Donut donut)
    {

    }
}
