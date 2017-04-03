using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour 
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void SetDifficulty(string difficulty)
    {
        if (difficulty == "Easy")
        {
            gameManager.timeDifficulty = 45;
            gameManager.turnDifficulty = 15;
        }
        else if (difficulty == "Normal")
        {
            gameManager.timeDifficulty = 30;
            gameManager.turnDifficulty = 10;
        }
        else if (difficulty == "Hard")
        {
            gameManager.timeDifficulty = 15;
            gameManager.turnDifficulty = 5;
        }
    }
}
