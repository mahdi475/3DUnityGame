using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text timerText;
    public float levelLoadDelay = 0.5f;
    public float currentTime = 0f;
    public float startingTime = 500;
    public bool stopCounting = false;
    public bool isWinning;
    public int timerSpeed = 1;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentTime = startingTime;
    }
    void Update()
    {
        if (stopCounting == true || currentTime <= 0 && isWinning)
        {
            return;
        }
        currentTime -= timerSpeed * Time.deltaTime;
        timerText.text = "Timer: " + currentTime.ToString("0");
        TimerDeath();
    }


    void TimerDeath()
    {
        if (currentTime < 0 && !isWinning)
        {
            StopTimer();
            StartCoroutine(ReloadLevel());
        }
    }
    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void StopTimer()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
