using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Vampire : Enemy
{
    private void Awake()
    {
        enemyName = "Vampire";
        strength = Random.Range(2, 3);
        health = Random.Range(8, 10);
    }

    // POLYMORPHISM
    public override void attack()
    {
        base.attack();
        heal();
    }

    // ABSTRACTION
    private void heal()
    {
        gameLog.text += enemyName + " bites You and heals for " + m_strength + " points!";
        health += m_strength;
    }
}
