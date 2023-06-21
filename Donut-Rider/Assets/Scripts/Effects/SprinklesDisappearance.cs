
using UnityEngine;

public class SprinklesDisappearance : MonoBehaviour
{
    private bool isDisappearing;
    private float DisapperaingSpeed;

    private void Awake()
    {
        DisapperaingSpeed = Random.Range(0.1f, 1f);
    }

    private void Update()
    {
        Disappers();
    }

    public void Disaper()
    {
        isDisappearing = true;
    }

    private void Disappers()
    {
        if (!isDisappearing)
            return;

        transform.localScale = Vector3.Lerp(new Vector3(1,1,1), Vector3.zero, Time.deltaTime * DisapperaingSpeed);

        if (transform.localScale == Vector3.zero)
            Destroy(this.gameObject);
    }
}
