using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadMain()
    {
        Debug.Log("click btn");
        SceneManager.LoadScene("SampleScene");
        GameObject fox = GameObject.Find("Fox");
        fox.transform.position = new Vector3(1, -3, 0);
    }
    public void quitApp()
    {
        Application.Quit();

    }
}
