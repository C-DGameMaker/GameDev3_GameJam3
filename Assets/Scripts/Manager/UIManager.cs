using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsUI;
    public GameObject pauseUI;
    public GameObject gamePlayUI;
    public GameObject inventoryUI;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    public void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }

    public void HideDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void SetDialogueText(string dialogueString)
    {
        dialogueText.text = dialogueString;
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void MainMenu()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void Settings()
    {
        HideAllUI();
        settingsUI.SetActive(true);
    }

    public void Pause()
    {
        HideAllUI();
        pauseUI.SetActive(true);
    }

    public void ShowIntventory()
    {
        HideAllUI();
        inventoryUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
