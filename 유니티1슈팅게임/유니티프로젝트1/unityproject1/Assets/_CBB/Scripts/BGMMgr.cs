using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{
    //BGMMgr 싱글톤 만들기
    //모든 씬에서 사용 가능해야하니 BGMMgr을 삭제하면 안 된다
    public static BGMMgr Instance;      //BGMMgr싱글톤 인스턴스

    private void Awake()
    {
        if(Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    Dictionary<string, AudioClip> bgmTable; //BGM파일들을 담아놓을 딕셔너리(STL의 맵과 같음)

    AudioSource audioMain;                  //메인 오디오
    AudioSource audioSub;                   //서브 오디오(BGM 교체 시 사용함)

    [Range(0, 1.0f)]                        //[]로 만들어져 있는 것을 Attribute라고 하고, 인스펙터 창 값을 0 ~ 1로 고정
    public float masterVolume = 1.0f;       //마스터 볼륨은 0 ~ 1
    float volumeMain = 0.0f;                //메인오디오 볼륨
    float volumeSub = 0.0f;                 //서브오디오 볼륨
    float crossFadeTime = 5.0f;             //크로스페이드 타임 5초

    void Start()
    {
        //BGM목록
        bgmTable = new Dictionary<string, AudioClip>();
        //오디오 소스 코드로 추가
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();
        //오디오 소스 볼륨 0으로 초기화
        audioMain.volume = 0.0f;
        audioSub.volume = 0.0f;
    }

    void Update()
    {
        //오디오가 플레이 중일때 메인볼륨은 올리고 서브볼륨은 내린다
        if(audioMain.isPlaying)
        {
            if(volumeMain < 1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime;
                if (volumeMain >= 1.0f) volumeMain = 1.0f;
            }

            if(volumeSub > 0.0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if (volumeSub >= 1.0f)
                {
                    volumeSub = 0.0f;
                    audioSub.Stop();
                }
            }
        }

        audioMain.volume = volumeMain * masterVolume;
        audioSub.volume = volumeSub * masterVolume;


    }

    //BGM플레이
    public void PlayBGM(string bgmName)
    {
        //딕셔너리 안에 오디오가 없으면 리소스 폴더에서 찾아서 새로 추가하자
        if(bgmTable.ContainsKey(bgmName) == false)
        {
            //유니티엔진에서 특별한 기능의 Resources폴더가 존재함
            //어디에서든 파일을 로드할 수 있다
            //단, 스펠링 주의

            //Resources/BGM/폴더 안에서 오디오클립을 찾는다
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //리소스폴더에 해당 bgm이 없다면 그냥 리턴하고 나오기
            //오디오파일이 없으니 재생할 수 없다
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);
        }

        //메인오디오의 클립에 새로운 오디오클립을 연결한다
        audioMain.clip = bgmTable[bgmName];
        //메인오디오 재생하기
        audioMain.Play();

        //볼륨값 세팅
        volumeMain = 1.0f;
        volumeSub = 0.0f;

    }

    public void CrossFadeBGM(string bgmName, float cfTime = 1.0f)
    {
        //딕셔너리 안에 오디오가 없으면 리소스 폴더에서 찾아서 새로 추가하자
        if (bgmTable.ContainsKey(bgmName) == false)
        {
            //유니티엔진에서 특별한 기능의 Resources폴더가 존재함
            //어디에서든 파일을 로드할 수 있다
            //단, 스펠링 주의

            //Resources/BGM/폴더 안에서 오디오클립을 찾는다
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //리소스폴더에 해당 bgm이 없다면 그냥 리턴하고 나오기
            //오디오파일이 없으니 재생할 수 없다
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);
        }

        //크로스페이드 타임
        crossFadeTime = cfTime;

        //메인오디오에서 플레이 되고 있는걸 서브오디오로 변경
        AudioSource temp = audioMain;
        audioMain = audioSub;
        audioSub = temp;

        //볼륨값도 스위칭
        float tempVolume = volumeMain;
        volumeSub = volumeMain;
        volumeSub = tempVolume;

        //메인오디오의 클립에 새로운 오디오 클립을 연결한다.
        audioMain.clip = bgmTable[bgmName];

        //메인오디오 플레이하기
        audioMain.Play();
    }


    public void PauseBGM()
    {
        audioMain.Pause();
    }

   
}
