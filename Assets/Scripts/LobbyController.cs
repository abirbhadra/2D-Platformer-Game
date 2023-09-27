using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(ReloadLevel);
    }

    public void ReloadLevel()
    {

        LevelSelection.SetActive(true);
        
    }
}
