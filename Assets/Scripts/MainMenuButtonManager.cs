using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject firstButton;

    private void Awake()
    {
        GameManager.Instance.eventSystemHandler.SetButton(firstButton);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
