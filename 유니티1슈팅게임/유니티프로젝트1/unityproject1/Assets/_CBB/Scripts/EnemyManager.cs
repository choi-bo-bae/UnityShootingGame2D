//using System;   //얘 있으면 랜덤 못씀
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //에너미 매니저의 역할 
    //에너미 프리팹을 공장에서 찍어낸다. (에너미 프리팹)
    //에너미 스폰 타임
    //에너미 스폰 위치

    public GameObject enemyFactory;     //에너미 공장 (에너미프리팹)

    //public GameObject spawnPoint;       //스폰 될 위치
    public GameObject[] spawnPoints;       //스폰 될 위치들

    float spawnTime = 0.5f;                    //스폰 타임
    float curTime = 0.0f;                      //누적 타임

    // Update is called once per frame
    void Update()
    {
        //에너미 생성과 동시에 발사함
        SpawnEnemy();
       
    }

   
    private void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발생
        //시간 누적타임으로 계산
        //게임에서 정말 자주 사용함

        curTime += Time.deltaTime;

        if(curTime > spawnTime)
        {
            //누적시간 초기화
            curTime = 0.0f;
            //스폰타임을 랜덤하게생성
            spawnTime = Random.Range(0.5f, 2.0f);

            //에너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            //enemy.transform.position = spawnPoint.transform.position;
            int index = Random.Range(0, spawnPoints.Length);
            //enemy.transform.position = transform.GetChild(index).position;
            enemy.transform.position = spawnPoints[index].transform.position;
        }
        
    }
}
