using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpCount : MonoBehaviour
{
    public Text scoreHolder;
    [SerializeField]
    private int ScoreValue = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            constant.JumpCount += ScoreValue;
            scoreHolder.text = constant.JumpCount.ToString();
            //ScoreValue++;
        }
        
    }
}
