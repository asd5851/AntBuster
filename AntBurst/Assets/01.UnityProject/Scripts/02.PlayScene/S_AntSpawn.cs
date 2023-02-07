using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AntSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    float delay_cur =default;
    float delay_max = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
        var spawnAnt = ObjectPoolingAnt.GetObject();
        spawnAnt.transform.position = transform.position;
    }
}
