using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _prePlayPanel;
    [SerializeField] private GameObject _gameOverPanel;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ActivatePrePlayMenu()
    {
        _prePlayPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }
    public void StartGame()
    {
        _prePlayPanel.SetActive(false);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Play);
    }

    public void ActivateGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        _prePlayPanel.SetActive(false);
    }
}
