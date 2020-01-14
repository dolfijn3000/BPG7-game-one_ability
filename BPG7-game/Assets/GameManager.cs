using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text text;
    [SerializeField] Button button;
    private float startTime;
    private void Start() {
        startTime = Time.time;
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
    }
}
