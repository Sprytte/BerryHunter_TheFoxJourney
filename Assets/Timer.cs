using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0f;
    public TextMeshProUGUI timerText;
    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = "Time: " +formattedTime;
    }
}

