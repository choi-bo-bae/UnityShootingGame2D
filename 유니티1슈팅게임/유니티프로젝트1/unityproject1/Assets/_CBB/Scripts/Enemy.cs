using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //위에서 아래로 떨어지기만 한다(똥피하기)
    //충돌처리(애너미랑 플레이어, 애너미랑 플레이어의 총알)

    public float speed = 10.0f;
    
    private float curTime = 0.0f;
    private float maxTime = 2.0f;

    public GameObject bulletFactory;
    public GameObject target;

    public Queue<GameObject> EnemyBulletPool;

    int bulletMax = 5;

    private void Start()
    {
        InitBulletPooling();
    }

    private void InitBulletPooling()
    {
        EnemyBulletPool = new Queue<GameObject>();

        for (int i = 0; i < bulletMax; i++)
        {
            GameObject enemyBullet = Instantiate(bulletFactory);
            enemyBullet.SetActive(false);
            EnemyBulletPool.Enqueue(enemyBullet);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //아래로 이동해라
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        enemyFire();
    }

    private void enemyFire()
    {
        if (target != null)
        {
            curTime += Time.deltaTime;

            if (curTime > maxTime)
            {
                if (EnemyBulletPool.Count > 0)
                {
                    GameObject enemyBullet = EnemyBulletPool.Dequeue();
                    enemyBullet.SetActive(true);
                    enemyBullet.transform.position = this.transform.position;
                    Vector3 dir = target.transform.position - this.transform.position;
                    dir.Normalize();
                    enemyBullet.transform.up = dir;

                    curTime = 0.0f;
                }
                else
                {
                    GameObject enemyBullet = Instantiate(bulletFactory);
                    enemyBullet.SetActive(false);
                    EnemyBulletPool.Enqueue(enemyBullet);

                    curTime = 0.0f;
                }
            }
        }
    }

   




  

}
