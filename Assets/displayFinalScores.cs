using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayFinalScores : MonoBehaviour
{
    [SerializeField]
    private Text jumpScoreHolder;

    [SerializeField]
    private Text timeScoreHolder;
    [SerializeField]
    private AudioSource winmusic;

    void Start()
    {
        //winmusic.Play();

        jumpScoreHolder.text = "Final Jump Score: " + PlayerPrefs.GetString("finalJumpScore");
        timeScoreHolder.text = "Time Completed: " + PlayerPrefs.GetString("finalTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
