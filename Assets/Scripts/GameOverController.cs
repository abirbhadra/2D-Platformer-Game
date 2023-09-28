using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
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
    }
    public void playerDied()
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
        

}
