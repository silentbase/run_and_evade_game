using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject spawnee;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObject", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObject()
    {
        float distance = Random.Range(-100f, 700f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 delta = new Vector2(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);

        Instantiate(spawnee, delta, Quaternion.Euler(10, 10, 10));
    }
}
