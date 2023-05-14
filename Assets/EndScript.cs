using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource btnclicksfx;
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
        btnclicksfx.Play();
        StartCoroutine(delayLoadingMain());
        GameObject fox = GameObject.Find("Fox");
        fox.transform.position = new Vector3(1, -3, 0);
    }
    public void quitApp()
    {
        btnclicksfx.Play();
        Application.Quit();

    }
    public void loadCredits()
    {
        btnclicksfx.Play();
        StartCoroutine(delayLoadingCreds());
        
    }
    private IEnumerator delayLoadingMain()
    {   
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }
    private IEnumerator delayLoadingCreds()
    {   
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("CreditsScene");
    }
   
}
