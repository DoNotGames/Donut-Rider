using UnityEngine;

public class DonutHealth
{
    private int hp;
    private int currentHP;

    private DonutMenager donutMenager;

    public DonutHealth(DonutMenager donutMenager)
    {
        hp = 3;
        currentHP = hp;

        this.donutMenager = donutMenager;
    }
    public void TakeDamage(int damage)
    {
        if (donutMenager.isInvulnerable)
            return;

        currentHP -= damage;
        donutMenager.isInvulnerable = true;
        donutMenager.EjectSprinkles();

        if (currentHP == 0)
        {
            Debug.Log("i'm dead");
        }
    }
}
