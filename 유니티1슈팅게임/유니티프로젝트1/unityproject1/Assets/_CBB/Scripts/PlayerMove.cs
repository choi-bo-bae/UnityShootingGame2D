using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float speed = 5.0f;//플레이어의 이동 속도



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //플레이어 이동 함수
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0.0f);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;

        //transform.Translate(dir * speed * Time.deltaTime);

        //위치 = 현재 위치 + (방향 * 시간)

        //Vector3 dir = new Vector3(h, v, 0);
        //transform.position += dir * speed * Time.deltaTime;
    }
}
