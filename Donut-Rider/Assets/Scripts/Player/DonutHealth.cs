using System;
using UnityEngine;

public class DonutHealth
{
    private int hp;
    public int currentHP { get; private set; }

    public Action PlayerDeath;

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
            PlayerDeath?.Invoke();
        }
    }
}
