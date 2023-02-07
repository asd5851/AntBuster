using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BulletMove : MonoBehaviour
{
    public int bulletDamage = default;
    public int bulletSpeed = default;

    Vector3 antPosition = default;
    void Start()
    {
    }
    void OnEnable()
    {
       // 활성화 되면 개미위치 찾아내
       
    }
    //! 개미의 포지션을 받는다.
    public void AimToAnt(Transform targetPosition)
    {
        antPosition = targetPosition.position;
    }

    void Update()
    {
        if(antPosition!=null && antPosition!=default)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, antPosition, Time.deltaTime*bulletSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ant")
        {
            ObjectPooingBullet.ReturnObject(gameObject);
        }
    }
    
}
