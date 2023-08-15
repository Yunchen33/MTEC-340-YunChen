using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    private float timeDuration = 3f * 60f;

    private float timer;

    [SerializeField] private TextMeshProUGUI firstMins;
    [SerializeField] private TextMeshProUGUI secondMins;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSec;
    [SerializeField] private TextMeshProUGUI secondSec;

    private float flashTimer;
    private float flashDuration = 1f;

    public GameOverMenu GameOverMenu;
    int score = 0;


    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else
        {
            Flash();
            Gameover();
        }
        
    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float miuntes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", miuntes, seconds);
        firstMins.text = currentTime[0].ToString();
        secondMins.text = currentTime[1].ToString();
        firstSec.text = currentTime[2].ToString();
        secondSec.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if(timer != 0){
            timer = 0;
            UpdateTimerDisplay(timer);
        }
        if (flashTimer <= 0){
            flashTimer = flashDuration;
        } else if(flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMins.enabled = enabled;
        secondMins.enabled = enabled;
        separator.enabled = enabled;
        firstSec.enabled = enabled;
        secondSec.enabled = enabled;
    }

    public void Gameover()
    {
        GameOverMenu.Setup(score);
    }

}
