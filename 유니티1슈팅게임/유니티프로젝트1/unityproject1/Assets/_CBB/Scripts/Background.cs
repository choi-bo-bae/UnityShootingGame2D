using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public MeshRenderer back;

    public float speed = 0.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //백그라운드 스크롤
        speed += 0.5f * Time.deltaTime;
        Vector2 bgFlow = new Vector2(0, speed);
        back.material.SetTextureOffset(1, bgFlow);

        //스피드가 너무 쌓인다 싶으면 지우기
        if(speed >= 5.0f)
        {
            speed = 0.0f;
        }
        //백그라운드 스크롤
    }

}
