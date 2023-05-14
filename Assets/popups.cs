using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class popups : MonoBehaviour
{
    public float[] sectionHeights = { 3.5f, 5.5f, 13, 24, 45.5f, 54, 69, 87.5f, 108, 134};
    public TextMeshProUGUI container;
    public TextMeshProUGUI fancy;

    private int count = 0;
    private bool inCoroutine = false;
    private string[] messages = { "I can smell the berry from here!", "I better hurry before the birds eat it.",
        "Use 'a' and 'd' or the left and right arrow keys to move.", "Use spacebar or the up arrow key to jump.", 
        "Hold the jump button to go higher.", "Now reach the top and get that berry!"};
    private string[] landmarks = { "1. An Introduction", "Watch out for the bird! It can push you off.", "Jump on the wall to bounce up.",
        "2. The Desert", "3. Cold", "Watch out for the platforms! They're slippery.", "Snow platforms shorten your jumps",
        "4. Climb", "Use the 'wasd' or arrow keys to move on the ladders.", "Swing on the vines and press the jump button to release.",
        "5. Airborne", "6. Finale"};

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayMessages());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= sectionHeights[count] && !inCoroutine)
        {
            StartCoroutine(displayLandmark());
        }
    }

    IEnumerator displayMessages()
    {
        for (int i = 0; i < 6; i++)
        {
            container.text = messages[i];
            yield return new WaitForSeconds(3f);
            if (i == 5)
                container.text = "";
        }
        yield return null;
    }

    IEnumerator displayLandmark()
    {
        inCoroutine = true;
        if (count == 0 || count == 3 || count == 8 || count == 9) { 
            fancy.text = landmarks[count];
            yield return new WaitForSeconds(3);
            fancy.text = "";
        }
        else if (count == 4 || count == 6)
        {
            fancy.text = landmarks[count];
            count++;
            container.text = landmarks[count];
            yield return new WaitForSeconds(3);
            container.text = "";
            fancy.text = "";
        }
        else
        {
            container.text = landmarks[count];
            yield return new WaitForSeconds(3);
            container.text = "";
        }
        if(count != sectionHeights.Length-1)
            count++;
        inCoroutine= false;
        yield break;
    }
}
