using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDie : MonoBehaviour
{

    public GameObject fxFactory;

    public float hp = 100.0f;

    public float damage = 0.5f;

    public float inithp = 100.0f;

    public Image hpBarImg;

    //애너미 충돌처리
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {

            //총알 오브젝트는 비활성화 시키기
            collision.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Enqueue(collision.gameObject);
        }

        if (gameObject.name.Contains("Enemy") && collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
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


    //보스 충돌처리
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (gameObject.name.Contains("Boss"))
            {

                hpBarImg.fillAmount -= damage;
                hp = hpBarImg.fillAmount;

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
