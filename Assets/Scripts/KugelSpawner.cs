using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;

    public GameObject player;

    private Rigidbody r;

    public Vector3 velocity;

    void Start()
    {      
        InvokeRepeating("CreateObject", 0f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
        
      
    }

    void CreateObject()
    {
        if (Vector3.Distance(player.transform.position, spawnPos.transform.position) < 120)
        {
            
            GameObject gameObject = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            r = gameObject.GetComponent<Rigidbody>();           
        }
    }

    void FixedUpdate()
    {
        if (r != null)
        {
            if (spawnPos.position.x < 0)
            {
                r.AddForce(velocity);

            }
            else
            {
                r.AddForce(velocity);

            }
        }
    }
}
