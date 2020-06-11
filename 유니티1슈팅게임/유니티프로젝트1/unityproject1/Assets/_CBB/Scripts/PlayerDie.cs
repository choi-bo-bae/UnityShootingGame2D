using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    public GameObject fxFactory;


    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);//플레이어 없앰

        Destroy(collision.gameObject);
  
        ShowEffect();//플레이어 펑
    }

    private void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;


        Destroy(fx, 1.0f);//1초 후에 없앰
    }


}
