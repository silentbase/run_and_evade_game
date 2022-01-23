using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziel : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
