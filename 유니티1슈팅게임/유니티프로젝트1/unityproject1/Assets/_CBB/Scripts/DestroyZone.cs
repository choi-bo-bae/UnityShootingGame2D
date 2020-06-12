using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider other)
    {
        // 이곳에서 트리거에 감지된 오브젝트 제거하기(총알, 에너미)
        // Destroy(other.gameObject);

        // 배열 사용 시
      // if(other.gameObject.name.Contains("Bullet"))
      // {
      //     other.gameObject.SetActive(false);
      // }

        //레이어로 충돌체 찾기
       // if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
       // {
       //     other.gameObject.SetActive(false);
       //     //플레이어 오브젝트의 플레이어 파이어 컴포넌트의 리스트 오브젝트풀 속성을 추가해줌
       //     PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
       //     pf.bulletPool.Add(other.gameObject);
       // }       


        //플레이어의 총알이 충돌 된 경우
        //충돌된 오브젝트가 총알이라면 총알 풀에 추가한다
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            //총알 오브젝트는 비활성화 시키기
            other.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            PlayerFire pf = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFire>();

            if (pf == null)
            {
                Destroy(other.gameObject);
            }
            else
            {
               
                pf.bulletPool.Enqueue(other.gameObject);
            }
        }   
        ////애너미의 총알이 충돌된 경우
        else if (other.gameObject.layer == LayerMask.NameToLayer("E_Bullet"))
        {
            //총알 오브젝트는 비활성화 시키기
            other.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            //Enemy ef = GameObject.Find("Enemy1(Clone)").GetComponent<Enemy>();
            Enemy ef = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();


            if (ef == null)
            {
                Destroy(other.gameObject);
                
            }
            else
            {
                ef.EnemyBulletPool.Enqueue(other.gameObject);
            }

        }
        else
        {
            Destroy(other.gameObject);
        }

    }

}
