using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleplayerPrefs : MonoBehaviour
{
    public InputField pointsField;

    public void ClearPointsText()
    {
        pointsField.text = "";
    }

    public void ChangePointsText()
    {
        PlayerPrefs.SetFloat("endPoints", float.Parse(pointsField.text));
    }

    public void PlaySingleplayerGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
