using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameoverMenu : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public BGMusic bgMusicManager;


    public void gameOver()
    {
        gameObject.SetActive(true);
        pointsText.text = "Point: " + ScoreManager.instance.Score.ToString();
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {

        if (bgMusicManager != null)
        {
            bgMusicManager.GetComponent<AudioSource>().Stop();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void ExitButtom()
    {

        if (bgMusicManager != null)
        {
            bgMusicManager.GetComponent<AudioSource>().Stop();
        }
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }

}
