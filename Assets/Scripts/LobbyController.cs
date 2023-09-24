using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public string Scene;

    public Button buttonRestart;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(ReloadLevel);
    }

    public void ReloadLevel()
    {

            SceneManager.LoadScene(1);
        
    }
}
