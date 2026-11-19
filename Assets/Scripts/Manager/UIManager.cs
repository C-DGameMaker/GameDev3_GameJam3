using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject pauseUI;
    public GameObject gamePlayUI;
    public TextMeshProUGUI goldAmount;
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
        settingsUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void GameplayUI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
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

    public void UpdateGoldText()
    {
        goldAmount.text = "Gold: " + PlayerController.movementController.gold;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
