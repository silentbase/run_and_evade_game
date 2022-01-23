using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodenSpawner : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject spawnee;

    public GameObject player;
    private GameObject g;

    private float i;

    // Start is called before the first frame update
    void Start()
    {
       
            InvokeRepeating("CreateObject", 0f, 1f);
      
    }

    void CreateObject()
    {
        if (i < 1)
        {
            if (Vector3.Distance(player.transform.position, spawnPos.transform.position) < 90)
            {

                g = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
                Debug.Log("Inst");
                i++;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
