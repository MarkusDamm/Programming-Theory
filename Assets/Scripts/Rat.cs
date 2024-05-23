using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Rat : Enemy
{
    private void Awake()
    {
        enemyName = "Rat";
        strength = Random.Range(1, 2);
        health = Random.Range(2, 5);
    }
}
