using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool IsPaused = false;
    public GameObject pauseCanvas;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                ResumeMe();
            else
                PauseMe();
        }

    }

    public void PauseMe()
    {
        Time.timeScale = 0;
        IsPaused = true;
        pauseCanvas.SetActive(true);
    }

    public void ResumeMe()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        pauseCanvas.SetActive(false);
    }
}
