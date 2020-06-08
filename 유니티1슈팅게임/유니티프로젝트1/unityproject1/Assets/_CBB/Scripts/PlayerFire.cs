﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //프리팹은 주로 팩토리(공장에서 찍어내듯이) 라는 이름을 사용
    public GameObject firePoint;

    public RaycastHit collObj;

    //레이저를 발사하기 위해 라인랜더러가 필요
    //선은 최소 2개 이상의 점 필요
    LineRenderer lr;//라인랜더러 컴포넌트
    
    //일정 시간동안만 레이저 보여주기
    public float maxTime = 2.0f;
    private float curTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //라인랜더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();
        //중요!
        //게임 오브젝트는 활성화 비활성화 => SetActive() 함수 사용
        //컴포넌트는 enabled 속성 사용
    }

    // Update is called once per frame
    void Update()
    {
          //Fire();
        //FireRay();
    }
    

    //총알 발사
    public void Fire()
    {

        //마우스 왼쪽 버튼 혹은 왼쪽 컨트롤 키
        //if(Input.GetButtonDown("Fire1"))
        //{
            //총알공장(총알프리팹)에서 총알을 무한으로 뽑아낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다

            //총알 게임오브젝트 생성
            //GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트 위치 지정
           // bullet.transform.position = firePoint.transform.position;
        //}
    }


    //레이저 발사
    public void FireRay()
    {
       
        //마우스 왼쪽 버튼 혹은 왼쪽 컨트롤 키
        if (Input.GetButtonDown("Fire1"))
        {
            //라인랜더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점, 끝점 필요
            lr.SetPosition(0, transform.position);

            //오브젝트와 충돌 지점을 끝점으로 변경한다.
            // lr.SetPosition(1, transform.position + Vector3.up * 10);

            //Ray로 충돌처리
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo;  //Ray와 충돌된 오브젝트의 정보를 담는다.
            
            
            //Ray와 충돌된 오브젝트가 있다
            if (Physics.Raycast(ray, out hitInfo))
            {
                //레이저의 끝점 지정
                lr.SetPosition(1, hitInfo.point);

                //충돌된 오브젝트 삭제
                //Contains("Enemy") =>Enemy(clone)이런것도 포함
                //if (hitInfo.collider.name.Contains("Enemy"))
                //{
                //    Destroy(hitInfo.collider.gameObject);
                //}

                //디스트로이존의 탑과는 충돌처리 되지 않도록 한다.
                if (hitInfo.collider.name != "Top")
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            
            }
            else
            {
                //충돌된 오브젝트가 없으니 끝점을 정해준다.
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
            
        }

        //일정 시간이 지나면 레이저 보여주는 기능 비활성화
        if (lr.enabled == true)
        {
            curTime += Time.deltaTime;
            if (curTime > maxTime)
            {
                lr.enabled = false;
                curTime = 0.0f;
            }
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.name == "Boss")
    //    {
    //        lr.SetPosition(1, transform.position + );
    //    }
    //}


    //파이어 버튼 클릭
    public void OnFireButtonClick()
    {
        //총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트 위치 지정
        bullet.transform.position = firePoint.transform.position;
    }

}
