using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Player _playerJedi;
    [SerializeField] private Player _playerEmpire;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _playerJedi.PlayerDied += OnPlayerDied;
        _playerEmpire.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerJedi.PlayerDied -= OnPlayerDied;
        _playerEmpire.PlayerDied -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayerDied()
    {
        _canvasGroup.alpha = 1;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);

        Time.timeScale = 0; // останавливаем игровое время
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
