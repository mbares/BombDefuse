using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Bomb : MonoBehaviour
{
    public Text keypadScreenText, modeText, modeCountdownText;
    public Image digit1Light, digit2Light, digit3Light, digit4Light;

    private GameManager gameManager;
    private LevelManager levelManager;
    private int digit1, digit2, digit3, digit4;
    private string codeString = "";
    private bool enterPressed = false;
    private int turnsLeft;
    private float timeLeft;
    private float timeLeftUntilLastFrame;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager.turnDefusal)
        {
            modeText.text = "Turns left";
            turnsLeft = gameManager.turnDifficulty;
            modeCountdownText.text = turnsLeft.ToString();
        }
        else
        {
            modeText.text = "Time left";
            timeLeft = gameManager.timeDifficulty;
            timeLeftUntilLastFrame = timeLeft;
            modeCountdownText.text = timeLeft.ToString();
        }

        while (digit1 == digit2 || digit1 == digit3 || digit1 == digit4 || digit2 == digit3 || digit2 == digit4 || digit3 == digit4)
        {
            digit1 = Random.Range(0, 10);
            digit2 = Random.Range(0, 10);
            digit3 = Random.Range(0, 10);
            digit4 = Random.Range(0, 10);
        }
        Debug.Log(digit1 + "" + digit2 + "" + digit3 + "" + digit4);
    }

    void Update()
    {
        if (gameManager.timeDefusal)
        {
            timeLeftUntilLastFrame -= Time.deltaTime;
            if (timeLeft - timeLeftUntilLastFrame >= 1)
            {
                timeLeft = Mathf.Round(timeLeftUntilLastFrame);
                modeCountdownText.text = timeLeft.ToString();
            }
            if (timeLeft <= 0)
            {                
                levelManager.LoadLevel("Lose");
            }
        }
        else if (gameManager.turnDefusal)
        {
            if (turnsLeft <= 0)
            {               
                levelManager.LoadLevel("Lose");
            }
        }
    }
    public void KeypadPress(string key)
    {
        if (enterPressed)
        {
            codeString = "";
            keypadScreenText.text = codeString;
            enterPressed = false;
            digit1Light.color = Color.white;
            digit2Light.color = Color.white;
            digit3Light.color = Color.white;
            digit4Light.color = Color.white;
        }

        if (codeString.Length < 4 && !codeString.Contains(key))
        {
            codeString += key;
            keypadScreenText.text += key + " ";
        }
    }

    public void KeypadBackspace()
    {
        if (codeString.Length != 0 && !enterPressed)
        {
            codeString = codeString.Substring(0, codeString.Length - 1);
            keypadScreenText.text = keypadScreenText.text.Substring(0, keypadScreenText.text.Length - 2);
        }
    }

    public void KeypadEnter()
    {
        if (codeString.Length == 4)
        {
            string digit1String = codeString.Substring(0, 1);
            string digit2String = codeString.Substring(1, 1);
            string digit3String = codeString.Substring(2, 1);
            string digit4String = codeString.Substring(3, 1);
            bool digit1Correct = false;
            bool digit2Correct = false;
            bool digit3Correct = false;
            bool digit4Correct = false;

            enterPressed = true;

            if (gameManager.turnDefusal)
            {
                turnsLeft--;
                modeCountdownText.text = turnsLeft.ToString();
            }

            if (digit1String == digit1.ToString())
            {
                digit1Light.color = Color.green;
                digit1Correct = true;
            }
            else if (digit1String == digit2.ToString() || digit1String == digit3.ToString() || digit1String == digit4.ToString())
            {
                digit1Light.color = Color.yellow;
            }
            else
            {
                digit1Light.color = Color.red;
            }

            if (digit2String == digit2.ToString())
            {
                digit2Light.color = Color.green;
                digit2Correct = true;
            }
            else if (digit2String == digit1.ToString() || digit2String == digit3.ToString() || digit2String == digit4.ToString())
            {
                digit2Light.color = Color.yellow;
            }
            else
            {
                digit2Light.color = Color.red;
            }

            if (digit3String == digit3.ToString())
            {
                digit3Light.color = Color.green;
                digit3Correct = true;
            }
            else if (digit3String == digit1.ToString() || digit3String == digit2.ToString() || digit3String == digit4.ToString())
            {
                digit3Light.color = Color.yellow;
            }
            else
            {
                digit3Light.color = Color.red;
            }

            if (digit4String == digit4.ToString())
            {
                digit4Light.color = Color.green;
                digit4Correct = true;
            }
            else if (digit4String == digit1.ToString() || digit4String == digit2.ToString() || digit4String == digit3.ToString())
            {
                digit4Light.color = Color.yellow;
            }
            else
            {
                digit4Light.color = Color.red;
            }

            if (digit1Correct && digit2Correct && digit3Correct && digit4Correct)
            {                
                levelManager.LoadLevel("Win");
            }
        }
    }
}
