using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CanonControl : MonoBehaviour
{
    
    S_BulletMove bulletMove = default;
    // Start is called before the first frame update
    void Start()
    {

        //bulletMove = GetComponent<S_BulletMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ant")
        {
            Debug.Log("개미들어옴");
            // { 총알 생성
            var bullet = ObjectPooingBullet.GetObject();
            bullet.transform.position = gameObject.transform.position;
            bulletMove = bullet.GetComponent<S_BulletMove>();
            // } 총알 생성
            // { 범위안에 들어온 개미를 향해 총을 쏜다.
                // 개미의 좌표를 bullet 오브젝트의 스크립트에게 전달한다.
                bulletMove.AimToAnt(other.transform);
            // } 범위안에 들어온 개미를 향해 총을 쏜다.
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

    }
}
