using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	public void LoadLevel(string name)
	{        
        if(name != "Game")
        {
            gameManager.turnDefusal = false;
            gameManager.timeDefusal = false;
        }
        SceneManager.LoadScene(name);        
	}   
	
    public void TurnDefusal()
    {
        gameManager.turnDefusal = true;
        LoadLevel("Game");
    }

    public void TimeDefusal()
    {
        gameManager.timeDefusal = true;
        LoadLevel("Game");
    }

   
}
