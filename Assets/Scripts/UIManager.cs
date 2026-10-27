using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
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

    public void Play()
    {
        gamePlayUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        gamePlayUI.SetActive(false);
    }

    public void ShowIntventory()
    {
        inventoryUI.SetActive(true);
        gamePlayUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
