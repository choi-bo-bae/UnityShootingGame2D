using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Ready : MonoBehaviour
{
    private Image fadeIn;
    private float start;

    // Start is called before the first frame update
    void Start()
    {
        fadeIn = GetComponent<Image>();
        start = 1f;
    }

    void Update()
    {
        GameReady();
    }

    private void GameReady()
    {
        Color fadeColor = fadeIn.color;
        
        start = 1f;
      
        fadeColor.a = Mathf.PingPong(Time.time, start);
        fadeIn.color = fadeColor; 
       
    }

    
}
