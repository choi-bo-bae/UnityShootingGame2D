using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDie : MonoBehaviour
{

    public GameObject fxFactory;

    private float damage = 2.0f;
    public float Damage
    {
        get { return damage; }
    }

    private float hp = 100.0f;
    public float bossHp { get { return bossHp; }}

 
    private float inithp = 100.0f;

    public Image hpBarImg;

    //애너미 충돌처리
    private void OnCollisionEnter(Collision collision)
    {
        //플레이어의 총알과의 충돌
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {

            //총알 오브젝트는 비활성화 시키기
            collision.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Enqueue(collision.gameObject);


            //애너미 충돌 시 디스트로이
            if (gameObject.name.Contains("Enemy"))
            {
                //자기 자신도 없애고

                Destroy(gameObject);
                //Destroy(collision.gameObject);

                //이펙트 보여주기
                showEffect();

                //적 캐릭터 사망 시 스코어 증가 후 저장
                ScoreManager.Instance.AddScore();
            }
        }
    }




    //보스 충돌처리
    //트리거가 아니라 콜리전으로 하면 보스가 계속 튕겨져 나간다.. 주의!
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (gameObject.name.Contains("Boss"))
            {
                
                hp -= damage;
                hpBarImg.fillAmount = hp * 0.01f;

                //총알 오브젝트는 비활성화 시키기
                other.gameObject.SetActive(false);
                //오브젝트풀에 추가만 해준다
                PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
                pf.bulletPool.Enqueue(other.gameObject);


                if (hp <= 0)
                {
                    Destroy(gameObject);

                    showEffect();
                    ScoreManager.Instance.AddScore();
                }
            }
        }
    }


    //폭발 이펙트
    void showEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
        Destroy(fx, 1.0f);//1초 후에 없앰
    }

}
