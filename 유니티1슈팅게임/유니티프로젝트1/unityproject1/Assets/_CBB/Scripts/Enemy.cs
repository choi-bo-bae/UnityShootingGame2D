using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //위에서 아래로 떨어지기만 한다(똥피하기)
    //충돌처리(애너미랑 플레이어, 애너미랑 플레이어의 총알)

    public float speed = 10.0f;

    //public int curScore = 0;
    //public int highScore = 0;
    //
    //public Text score;
    //public Text h_Score;


    private void Start()
    {
        //score = GetComponent<Text>();
        //h_Score = GetComponent<Text>();
    }

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

        //점수 추가
        ScoreManager.Instance.AddScore();

        //적 캐릭터 사망 시 스코어 증가 후 저장
        //curScore++;
        //score.text = "Score : " + curScore;
        //PlayerPrefs.SetInt("SCORE", curScore);
    }
    


    //public void saveScore()
    //{
    //    if (curScore > highScore)
    //    {
    //        highScore = curScore;
    //        //PlayerPrefs.SetInt("HIGHSCORE", highScore);
    //        //h_Score.text = "HighScore : " + highScore.ToString("00");
    //    }
    //}
    

    //public void loadScore()
    //{
    //   // PlayerPrefs.GetInt("HIGHSCORE", highScore);
    //   // h_Score.text = "HighScore : " + highScore.ToString("00");
    //}

}
