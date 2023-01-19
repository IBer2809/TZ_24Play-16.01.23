using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { PrePlay, Play, GameOver};
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        CurrentState = GameState.PrePlay;
        UIManager.Instance.ActivatePrePlayMenu();
    }

    private void Update()
    {
        if(CurrentState == GameState.GameOver)
        {
            Stack.Instance.ChangeCubesConstaints();
        }
    }


    public void ChangeGameState(GameState state) => CurrentState = state;

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

}
