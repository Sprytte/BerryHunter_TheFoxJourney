using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenuCS : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadMain()
    {
        SceneManager.LoadScene("SampleScene");


    }
    public void quitApp()
    {
        Application.Quit();

    }

}
