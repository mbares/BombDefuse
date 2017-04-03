using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int timeDifficulty = 30;
    public int turnDifficulty = 10;
    public bool turnDefusal;
    public bool timeDefusal;

    void Awake()
    {    

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }  
  
}