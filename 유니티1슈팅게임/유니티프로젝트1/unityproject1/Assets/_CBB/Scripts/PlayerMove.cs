using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float speed = 5.0f;//플레이어의 이동 속도
    public Vector2 margin;  //뷰 포트좌표는 0.0f ~ 1.0f 사이

    //조이스틱 사용하기
    public VariableJoystick joystick;//조이스틱

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
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

        //조이스틱 사용하기
        //키보드가 안눌려 있을 때 => 조이스틱 사용하면 됨
        if(h == 0 && v == 0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        }


        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0.0f);
        
        //Vector3 dir = Vector3.right * h + Vector3.up * v;

        //transform.Translate(dir * speed * Time.deltaTime);

        //위치 = 현재 위치 + (방향 * 시간)
        //Vector3 dir = new Vector3(h, v, 0);
        //transform.position += dir * speed * Time.deltaTime;


        //플레이어가 화면 밖으로 나가지 않도록 하기
        MoveInScreen();
    }

    private void MoveInScreen()
    {
        //방법은 크게 3가지
        //첫 번째 : 화면 밖의 공간에 큐브 4개를 만들어서 배치
        //리지드 바디의 충돌체로 이동 못하게 막기

        //두 번째 : 플레이어의 포지션으로 이동 처리
        //아래와 같이 transform.position의 값을 벡터3에 다마아서 계산 후 다시 대입시키는 과정을 캐스팅 이라고 한다.
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;


        //세 번째 : 메인카레라의 뷰포트를 가져와서 처리한다(이거 사용할거임)
        //스크린 좌표 : 왼쪽 하단 (0, 0), 우측 상단(maxX, maxY)
        //뷰포트 좌표 : 왼쪽 하단(0, 0), 우측 상단 (1.0f, 1.0f)
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }
}
