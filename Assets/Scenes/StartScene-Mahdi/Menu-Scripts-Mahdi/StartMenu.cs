using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animation playAnimtion;
    public Animation settingsAnimation;
    public Animation quitAnimation;

    public GameObject canvas;
    public GameObject settings;

    public void Play()
    {
        playAnimtion.Play("Button_Animation");

        StartCoroutine(DelayBeforeStart(1));
    }
    public void GoBack()
    {
        playAnimtion.Play();

        StartCoroutine(DelayBeforeTryAgain(1));
    }


    public void Quit()
    {
        quitAnimation.Play("Button_Animation");

        StartCoroutine(DelayBeforeQuit(1));
    }

    public void Settings()
    {
        settingsAnimation.Play("Button_Animation");

        StartCoroutine(DelayBeforeSettings(1));
    }

    IEnumerator DelayBeforeStart(float value)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator DelayBeforeTryAgain(float value) 
    { 
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator DelayBeforeQuit(float value)
    {
        yield return new WaitForSeconds(value);
        Application.Quit();
    }

    IEnumerator DelayBeforeSettings(float value)
    {
        yield return new WaitForSeconds(value);
        canvas.SetActive(false);
        settings.SetActive(true);
    }
}
