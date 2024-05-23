using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Text gameLog;
    private Enemy currentEnemy;
    [SerializeField] GameObject enemyGameObject;
    static GameManager Instance;

    private void Start()
    {
        if (!GameManager.Instance)
        {
            GameManager.Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartGame(string enemy)
    {
        switch(enemy)
        {
            case "Rat":
                enemyGameObject.AddComponent<Rat>();
                currentEnemy = enemyGameObject.GetComponent<Rat>();
                break;
            case "Orc":
                enemyGameObject.AddComponent<Orc>();
                currentEnemy = enemyGameObject.GetComponent<Orc>();
                break;
            case "Vampire":
                enemyGameObject.AddComponent<Vampire>();
                currentEnemy = enemyGameObject.GetComponent<Vampire>();
                break;
            default:
                Debug.LogError("Invalid Enemy Type Name!");
                break;
        }
        // ABSTRACTION
        ActivateGameCanvas(true);
    }

    public static void EndGame()
    {
        GameManager.Instance.ActivateGameCanvas(false);
    }

    public void PlayerAttack()
    {
        gameLog.text = "";
        int attackDamage = Random.Range(1, 6);
        currentEnemy.takeDamage(attackDamage);
        EnemyMove(); // ABSTRACTION
    }

    public void PlayerDefend()
    {
        gameLog.text = ""; 
        EnemyMove(); // ABSTRACTION
    }

    // ABSTRACTION
    private void EnemyMove()
    {
        gameLog.text += "\n Enemy attacks";
        currentEnemy.attack();
    }

    // ABSTRACTION
    public void ActivateGameCanvas(bool game)
    {
        gameCanvas.gameObject.SetActive(game);
        menuCanvas.gameObject.SetActive(!game);
    }
}
