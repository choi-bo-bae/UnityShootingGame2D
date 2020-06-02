using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleSelect : MonoBehaviour
{
    public GameObject auto;
    private bool state;

    public GameObject autoBullet;

    public float speed = 3.0f;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state == false)
            {
                auto.gameObject.SetActive(true);
                state = true;
            }
            else if(state == true)
            {
                auto.gameObject.SetActive(false);
                state = false;
            }
        }

        AutoBulletFire();
       
    }

    private void AutoBulletFire()
    {
        if (state == true)
        {
            count++;
            autoBullet.transform.position = this.transform.position;

            if (count % 30 == 0)
            {
                GameObject bullet = Instantiate(autoBullet);
                
                autoBullet.transform.Translate(Vector3.up * speed * Time.deltaTime);
                count = 0;
            }
        }
    }


}
