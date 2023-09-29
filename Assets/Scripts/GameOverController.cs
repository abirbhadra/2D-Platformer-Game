using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    public Button buttonNextLevel;
    private void Awake()
    {
        if (buttonRestart != null)
        {
            buttonRestart.onClick.AddListener(ReloadLevel);
        }
        if (buttonLobby != null)
        {
            buttonLobby.onClick.AddListener(LoadLobby);
        }
        if(buttonNextLevel != null)
        {
            buttonNextLevel.onClick.AddListener(LoadNextLevel);
        }
    }
    public void playerDied()
    {
        gameObject.SetActive(true);
    }

    public void playerHitTeleporter()
    {
        gameObject.SetActive(true);
    }


    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        

}
