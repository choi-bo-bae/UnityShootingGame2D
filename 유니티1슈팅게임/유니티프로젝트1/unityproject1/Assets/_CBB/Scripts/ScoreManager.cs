﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       //유니티 엔진의 GUI에 접근 가능
using TMPro;                //텍스트메시 프로 사용 시

public class ScoreManager : MonoBehaviour
{
    //스코어 매니져 싱글톤 만들기
    public static ScoreManager Instance;
    private void Awake() => Instance = this;

    public Text ScoreTxt;               //일반 UI텍스트          
    public Text HighScoreTxt;           //일반 UI텍스트
   // public TextMeshProUGUI textTxt;     //텍스트메시 프로


    int score = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //하이스코어 불러오기
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreTxt.text = "HighScore : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //하이스코어 갱신
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            HighScoreTxt.text = "HighScore" + highScore;
        }
    }

    //점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        ScoreTxt.text = "Score :" + score;

        //텍스트 메시 프로
        //textTxt.text = "test???????";
    }
}
