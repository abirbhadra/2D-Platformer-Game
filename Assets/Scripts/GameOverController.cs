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
           //AudioManager.Instance.Play(Audios.ButtonClick);
            buttonRestart.onClick.AddListener(ReloadLevel);
        }
        if (buttonLobby != null)
        {
            //AudioManager.Instance.Play(Audios.ButtonClick);
            buttonLobby.onClick.AddListener(LoadLobby);
        }
        if(buttonNextLevel != null)
        {
            //AudioManager.Instance.Play(Audios.ButtonClick);
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
        AudioManager.Instance.Play(Audios.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLobby()
    {
        AudioManager.Instance.Play(Audios.ButtonClick);
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        AudioManager.Instance.Play(Audios.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        

}
