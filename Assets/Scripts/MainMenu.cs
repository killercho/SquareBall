using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {

    }

    public void QuitGame(){
        Debug.Log("Game exited with code 0!");
        Application.Quit();
    }
}
