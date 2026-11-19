using System;
using UnityEngine;

public enum GameStates
{
    init,
    mainMenu,
    gamePlay,
    paused,
    gameWin,
    gameOver,

}

public class GameStateManager : MonoBehaviour
{
    [Header("Game States")]

    public GameStates currentState;
    public GameStates previousState;

    private void Start()
    {
        SetGameStates(GameStates.init);
    }
    public void SetGameStates(GameStates newState)
    {
        previousState = currentState;
        currentState = newState;

        SwitchGameStates(newState);
    }

    private void SwitchGameStates(GameStates switchedState)
    {
        switch (switchedState)
        {
            default:
                break;

            case GameStates.init:
                SetGameStates(GameStates.mainMenu);
                GameManager.Instance.saveDataManager.PlayerData();
                break;

            case GameStates.mainMenu:
                GameManager.Instance.UIManager.HideAllUI();
                break;

            case GameStates.gamePlay:
                GameManager.Instance.UIManager.GameplayUI();
                Time.timeScale = 1;
                break;

            case GameStates.paused:
                GameManager.Instance.UIManager.Pause();
                Time.timeScale = 0;
                break;

            case GameStates.gameWin:
                break;

            case GameStates.gameOver:
                break;
        }

    }
}
