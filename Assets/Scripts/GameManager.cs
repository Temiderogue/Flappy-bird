using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _restartButton, _blackScreen;
    [SerializeField] private Text _text, _bestScoreText;


    private void Start()
    {
        _blackScreen.enabled = false;
        _restartButton.enabled = false;
        _text.enabled = false;
        _bestScoreText.enabled = false;
    }
    public void GameOver()
    {
        if (_player.ScoreAmount > Data.BestScore)
        {
            Data.BestScore = _player.ScoreAmount;
        }
        _bestScoreText.enabled = true;
        _bestScoreText.text = "Best score: " + Data.BestScore.ToString();

        _blackScreen.enabled = true;
        _restartButton.enabled = true;
        _text.enabled = true;
        _bestScoreText.enabled = true;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
