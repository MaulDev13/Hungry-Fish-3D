using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] string homeScene = "Home";

    [SerializeField] float timer = 60f;
    [SerializeField] float currentTimer = 0f;

    [SerializeField] Transform endPanel;
    [SerializeField] TextMeshProUGUI endTxt;

    [SerializeField] TextMeshProUGUI timerTxt;

    [SerializeField] PlayerCollider player;

    bool isEnd = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        endPanel.gameObject.SetActive(false);
        currentTimer = timer;

        player.onDead += PlayerDead;
    }

    private void OnDisable()
    {
        player.onDead -= PlayerDead;
    }

    private void Update()
    {
        if (isEnd)
            return;

        if (currentTimer <= 0f)
        {
            currentTimer = 0f;
            TimerTxt();
            End();
        }
        else
        {
            currentTimer -= Time.deltaTime;
            TimerTxt();
        }
    }

    void PlayerDead()
    {
        End();
    }

    void End()
    {
        isEnd = true;

        Cursor.lockState = CursorLockMode.None;

        if (player.IsDead)
            endTxt.text = "KAMU KALAH!";
        else
            endTxt.text = "KAMU MENANG!";

        endPanel.gameObject.SetActive(true);
    }

    public void OnBtnHome()
    {
        SceneManager.LoadScene(homeScene);
    }

    public void OnBtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TimerTxt()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTimer);
        timerTxt.text = time.ToString("hh':'mm':'ss");
    }
}
