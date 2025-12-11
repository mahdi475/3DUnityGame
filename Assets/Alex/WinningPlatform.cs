using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WinningPlatform : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int delay;
    GameObject cameraToFreeze;
    private Timer timerScript;
    private Score animatorFromScore;

    private void Awake()
    {
        animatorFromScore = FindObjectOfType<Score>();
        timerScript = FindObjectOfType<Timer>();
        cameraToFreeze = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorFromScore.animator.SetBool("ShowScore", true);
            timerScript.scoreText.text = timerScript.currentTime.ToString("Score: " + "0");
            timerScript.isWinning = true;
            timerScript.timerSpeed = 300;
            StartCoroutine(DelayLoadScene());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<PlayerInput>().enabled = false;
            cameraToFreeze.GetComponent<CinemachineBrain>().enabled = false;
        }
    }

    IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}