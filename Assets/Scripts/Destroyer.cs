﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject g;

    public float lifeTime = 10f;

    private GameObject player;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;

            if(lifeTime <= 0)
            {
                Destruction();
            }
        }
        if (this.transform.position.y <= -20) {
            Destruction();
        }
        

    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
