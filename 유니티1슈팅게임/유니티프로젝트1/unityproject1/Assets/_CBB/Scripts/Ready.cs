using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ready : MonoBehaviour
{
    private Image fadeIn;
    private float time;
    private float start;
    private float end;

    // Start is called before the first frame update
    void Start()
    {
        fadeIn = GetComponent<Image>();
        start = 1f;
        end = 0f;
        
    }

    void Update()
    {
        GameReady();
    }

    private void GameReady()
    {
        Color fadeColor = fadeIn.color;
        time += Time.deltaTime;

      
        if (fadeColor.a > 0)
        {
            start = 1f;
            end = 0f;
            fadeColor.a = Mathf.Lerp(start, end, time);
            fadeIn.color = fadeColor; 
        }

        if(fadeColor.a <= 0)
        {
            start = 1f;
            end = 0f;
            fadeColor.a = Mathf.Lerp(end, start, time);
            fadeIn.color = fadeColor;
        }
        
    }

    
}
