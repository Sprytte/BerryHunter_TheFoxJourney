using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenuCS : MonoBehaviour
{
    [SerializeField]
    Canvas mainMenu,optionsMenu;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Toggle mute;
    [SerializeField]
    private AudioSource btnclicksfx;
    void Start()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadMain()
    {
        btnclicksfx.Play();
        SceneManager.LoadScene("SampleScene");


    }
    public void quitApp()
    {
        btnclicksfx.Play();
        Application.Quit();

    }
    public void loadOptions()
    {
        btnclicksfx.Play();
        optionsMenu.enabled= true;
        mainMenu.enabled= false;
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
    public void loadMainMenu()
    {
        btnclicksfx.Play();
        mainMenu.enabled = true;
        optionsMenu.enabled = false;

    }


}
