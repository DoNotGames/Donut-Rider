using System.Collections.Generic;
using UnityEngine;

public class DonutEffects
{
    private GameObject vfx;

    public DonutEffects(GameObject vfx)
    {
        this.vfx = vfx;
    }

    public void Flicker()
    {
        if (Time.fixedTime % .2 < .1)
        {
            vfx.SetActive(false);
            return;
        }

        vfx.SetActive(true);
    }

    public void ShowVFX()
    {
        vfx.SetActive(true);
    }

    public void EjectSprinkles(Transform sprinklesToEject)
    {
        List<Transform> ejectedSprincles = new List<Transform>();

        foreach(Transform sprinkle in sprinklesToEject)
        {
            ejectedSprincles.Add(sprinkle);
        }

        foreach(Transform ejectedSprincle in ejectedSprincles)
        {
            ejectedSprincle.parent = null;
            Rigidbody sprinkleRigidbody = ejectedSprincle.GetComponent<Rigidbody>();
            sprinkleRigidbody.isKinematic = false;
            sprinkleRigidbody.AddForce(new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f)), ForceMode.Impulse);
            ejectedSprincle.GetComponent<SprinklesDisappearance>().Disaper();
        }
    }
}
