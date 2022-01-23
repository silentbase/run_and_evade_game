using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelGeschossVelo : MonoBehaviour
{
    public Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        r.AddForce(new Vector3(70, 0, 0));
    }
}
