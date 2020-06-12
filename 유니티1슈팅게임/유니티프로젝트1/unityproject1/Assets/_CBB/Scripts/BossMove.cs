using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private float max;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        max = 1.0f;

        transform.position = new Vector2(Mathf.PingPong(Time.time, max), transform.position.y);

    }
}
