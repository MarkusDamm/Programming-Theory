using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected string enemyName;
    [SerializeField] protected Text gameLog;
    protected int strength
    {
        get { return strength; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Strengh can't be set to a negative value!");
            }
            else
            {
                strength = value;
            }
        }
    }
    protected int health;

    protected void Start()
    {
        gameLog = GameObject.Find("Game Canvas").GetComponentInChildren<Text>();
    }

    protected virtual void attack()
    {
        gameLog.text += "%20 You take " + strength + " points of damage!";
    }

    public virtual void takeDamage(int damageTaken)
    {
        health -= damageTaken;
        string output = "%20 " + enemyName + " took " + damageTaken + " points of damage! ";
        if (health <= 0)
        {
            gameLog.text += output;
            die();
        }
        else
        {
            output += health + " HP remain.";
            gameLog.text += output;
        }
    }

    protected void die()
    {
        gameLog.text += "Congratulations! You defeated " + enemyName;
    }
}
