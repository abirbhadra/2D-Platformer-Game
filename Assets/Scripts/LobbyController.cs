using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayLevel);
    }

    public void PlayLevel()
    {
        AudioManager.Instance.Play(Audios.ButtonClick);
        LevelSelection.SetActive(true);
        
    }
}
