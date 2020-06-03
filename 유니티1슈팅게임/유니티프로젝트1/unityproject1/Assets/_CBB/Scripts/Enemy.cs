using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //위에서 아애로 떨어지기만 한다(똥피하기)
    //충돌처리(애너미랑 플레이어, 애너미랑 플레이어의 총알)

    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //아래로 이동해라
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자기 자신도 없애고
        //충돌된 오브젝트도 없앤다
        Destroy(gameObject);
        //Destroy(gameObject, 1.0f);//1초 후에 없앰
        Destroy(collision.gameObject);
    }




}
