using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class JumpCount : MonoBehaviour
{
    public TextMeshProUGUI scoreHolder;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            constant.JumpCount ++;
            scoreHolder.text = "Jump Count: "+ constant.JumpCount.ToString();
            //ScoreValue++;
        }
        
    }
}
