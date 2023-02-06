using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AntControl : MonoBehaviour
{
    private GameObject cake;
    private GameObject antSpawn;
    int hp = default;
    public int HP
    {
        get
        {
            return hp;
        }
    }

    bool goWhere = false;
    // Start is called before the first frame update
    void Start()
    {
        antSpawn = GameObject.Find("AntSpawn");
        cake = GameObject.Find("Cake");
    }

    // Update is called once per frame
    void Update()
    {
        if(!goWhere)
            MoveCake();
        else{
            MoveSpawn();
        }
    }
    //! 개미가 케이크로 움직인다.
    void MoveCake()
    {
        transform.position = Vector3.MoveTowards(transform.position, cake.transform.position, Time.deltaTime);
    }

    //! 개미가 스폰지점으로 움직인다.
    void MoveSpawn()
    {
        transform.position = Vector3.MoveTowards(transform.position, antSpawn.transform.position, Time.deltaTime);
    }

    //! 개미가 케이크를 만났을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Cake")
        {
            goWhere = true;
            // 개미의 애니메이션을 변경한다.
        }
        else if(other.gameObject.tag == "AntSpawn")
        {
            Debug.Log("만낫니");
            goWhere = false;
        }
    }
}
