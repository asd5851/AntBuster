using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ant = default;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ant.transform.position, Time.deltaTime);
    }

    
}
