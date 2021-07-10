using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    public BallScript BallScript;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverPlayer;

    private int blueDeaths;
    private int yellowDeaths;
    private float endPoints;

    private void Start()
    {
        endPoints = PlayerPrefs.GetFloat("endPoints");
    }

    private void Update()
    {
        blueDeaths = BallScript.GetBlueDeaths();
        yellowDeaths = BallScript.GetYellowDeaths();
        if(blueDeaths >= endPoints)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            gameOverPlayer.text = "The AI wins!";
            
        }
        else if (yellowDeaths >= endPoints)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            gameOverPlayer.text = "The PLAYER wins!";
        }
    }
}
