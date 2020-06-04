using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{

    //public GameObject bossFactory;
    //public GameObject target;
    //public GameObject bossFirePos;
    //public float speed = 3.0f;
    //private float maxTime = 1.0f;
    //private float curTime = 0.0f;



    //보스 총알 발사 (총알 패턴)
    //1. 플레이어를 향해서 총알 발사
    //2. 회전 총알 발사

    public GameObject bulletFactory;    //총알 프리팹
    public GameObject target;           //플레이어 타겟

    public GameObject bossFirePos;


    public float fireTime = 1.0f;
    float curTime = 0.0f;

    public float fireTime1 = 1.5f;      //1.5초에 한번씩 발사
    float curTime1 = 0.0f;
    int bulletMax = 10;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //curTime += Time.deltaTime;

        //if(curTime >= maxTime)
        //{
        //   GameObject bullet = Instantiate(bossFactory);
        //   bossFactory.transform.position = bossFirePos.transform.position;

        //   curTime = 0.0f;
        //}

        AutoFire1();
        AutoFire2();
    }

  
    //플레이어를 향해서 총알 발사
    private void AutoFire1()
    {
        //타겟이 없을 때 에러 발생하니 예외처리
        if (target != null)
        {
            curTime += Time.deltaTime;

            if (curTime > fireTime)
            {
              

                    //총알 공장에서 총알 생성
                    GameObject bullet = Instantiate(bulletFactory);
                    //총알 생성 위치
                    bullet.transform.position = bossFirePos.transform.position;
                    //플레이어가 있는 방향 구하기(벡터의 뺄셈)
                    Vector3 dir = target.transform.position - bossFirePos.transform.position;
                    dir.Normalize();
                    //총구의 방향도 맞춰 준다(이게 중요함)
                    bullet.transform.up = dir;
                

                //타이머 초기화
                curTime = 0.0f;

            }
        }
    }

    //회전 총알 발사
    private void AutoFire2()
    {
        //타겟이 없을 때 에러 발생하니 예외처리
        if (target != null)
        {
            curTime1 += Time.deltaTime;

            if (curTime1 > fireTime1)
            {
                for (int i = 0; i < bulletMax; i++)
                {

                    //총알 공장에서 총알 생성
                    GameObject bullet = Instantiate(bulletFactory);
                    //총알 생성 위치
                    bullet.transform.position = bossFirePos.transform.position;
                    //360도 방향으로 발사
                    float angle = 360.0f / bulletMax;
                    //총구의 방향도 맞춰 준다(이게 중요함)
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }

                //타이머 초기화
                curTime1 = 0.0f;

            }
        }
    }
}
