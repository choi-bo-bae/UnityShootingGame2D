using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //프리팹은 주로 팩토리(공장에서 찍어내듯이) 라는 이름을 사용
    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();  
    }

    private void Fire()
    {

        //마우스 왼쪽 버튼 혹은 왼쪽 컨트롤 키
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한으로 뽑아낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트 위치 지정
            bullet.transform.position = firePoint.transform.position;
        }
    }
}
