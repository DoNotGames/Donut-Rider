using UnityEngine;

public class Spikes : Trap
{
    public override void React(Donut donut)
    {
        Debug.Log("spikes");
    }
}
