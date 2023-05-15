using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    
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
    [SerializeField]
    private AudioSource btnclicksfx;


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
        btnclicksfx.Play();
        Time.timeScale = 1f;
        IsPaused = false;
        pauseCanvas.SetActive(false);
    }
    public void exit()
    {
        btnclicksfx.Play();
        Application.Quit();
    }
    public void loadOptionsMenu()
    {
        btnclicksfx.Play();
        optionsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        
    }
    public void loadPause()
    {
        btnclicksfx.Play();
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
