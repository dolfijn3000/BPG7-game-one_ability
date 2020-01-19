using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] Animator scoreAnimator;
    [SerializeField] TextMeshProUGUI scoreText;
    [Header("restart screen")]
    [SerializeField] GameObject panel;
    [SerializeField] Text text;
    [SerializeField] Button button;
    private float startTime;
    private void Start()
    {
        startTime = Time.time;
        ScoreManager.anim = scoreAnimator;
        ScoreManager.text = scoreText;
    }
    public void RestartGame()
    {
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
            GameState.IsRunning = true;
        });
        text.text = $"you survived for { (Time.time - startTime).ToString("0.0") } seconds";
        panel.SetActive(true);
        ScoreManager.Score = 0;
    }
}
