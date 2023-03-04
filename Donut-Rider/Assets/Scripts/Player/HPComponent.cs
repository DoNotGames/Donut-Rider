using System.Xml.Serialization;
using UnityEngine;

public class HPComponent : MonoBehaviour
{
    private int hp;
    public int HP
    { 
        get { return hp; }

        set
        {
            if (value != hp)
            {
                hp = value;
                onHealthChanged?.Invoke(hp);

                if (hp < 1)
                {
                    donut.GameOver();
                }
            }
        }
    }

    private Donut donut;

    public delegate void OnHealthChanged(int hp);
    public event OnHealthChanged onHealthChanged;

    HPComponent()
    {
        hp = 3;
    }

    private void Awake()
    {
        donut = GetComponent<Donut>();
        if (donut == null)
        {
            Debug.LogWarning("Donut is not valid");
        }
    }
}
