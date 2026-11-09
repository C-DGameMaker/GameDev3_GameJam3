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

    [SerializeField] GameStates currentState;
    [SerializeField] GameStates previousState;

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
                break;

            case GameStates.gamePlay:
                break;

            case GameStates.paused:
                break;

            case GameStates.gameWin:
                break;

            case GameStates.gameOver:
                break;
        }

    }
}
