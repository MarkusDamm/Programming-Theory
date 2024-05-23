using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected string enemyName;
    [SerializeField] protected Text gameLog;
    protected int m_strength;
    // ENCAPSULATION
    protected int strength
    {
        get { return m_strength; }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Strengh can't be set to a negative value!");
            }
            else
            {
                m_strength = value;
            }
        }
    }
    protected int health;

    protected void Start()
    {
        gameLog = GameObject.Find("Game Log").GetComponent<Text>();
    }

    public virtual void attack()
    {
        gameLog.text += "\n You take " + strength + " points of damage! ";
    }

    public virtual void takeDamage(int damageTaken)
    {
        health -= damageTaken;
        string output = "\n " + enemyName + " took " + damageTaken + " points of damage! ";
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

    // ABSTRACTION
    protected void die()
    {
        gameLog.text += "Congratulations! You defeated " + enemyName;
        GameManager.EndGame();
    }
}
