using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private Text jumpScoreHolder;

    [SerializeField]
    private Text timeScoreHolder;
    public bool IsPaused = false;
    public GameObject pauseCanvas;
    [SerializeField]
    private AudioSource pausesfx;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausesfx.Play();

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
        jumpScoreHolder.text = "Jumps: " + PlayerPrefs.GetString("finalJumpScore");
        timeScoreHolder.text = "Time: " + PlayerPrefs.GetString("finalTime");
    }

    public void ResumeMe()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        pauseCanvas.SetActive(false);
    }
}
