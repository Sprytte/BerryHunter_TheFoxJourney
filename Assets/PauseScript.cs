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
    public GameObject optionsCanvas;
    [SerializeField]
    private AudioSource pausesfx;
    //[SerializeField]
    //Canvas pauseMenu, optionsMenu;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Toggle mute;
   

    void Start()
    {
        //pauseMenu.enabled = false;
        //optionsMenu.enabled = false;
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
        //pauseMenu.enabled = true;
        pauseCanvas.SetActive(true);  
    }
    public void ResumeMe()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        pauseCanvas.SetActive(false);
    }
    public void loadOptionsMenu()
    {
        optionsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        
    }
    public void loadPause()
    {
        optionsCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
            
    }
    public void ChangeVolume()
    {
        if (mute.isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }
}
