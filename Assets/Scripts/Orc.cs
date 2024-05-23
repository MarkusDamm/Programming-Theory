using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    private void Awake()
    {
        enemyName = "Orc";
        strength = Random.Range(3, 5);
        health = Random.Range(12, 15);
    }

    public override void takeDamage(int damageTaken)
    {
        base.takeDamage(damageTaken);
        attack();
    }
}
