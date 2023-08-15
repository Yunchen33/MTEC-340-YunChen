using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI pointText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        //pointText.text = "You get: " + score.ToString() + "Orders.";
    }

    public void RestartButton()
    {
        
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void HomeBotton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
