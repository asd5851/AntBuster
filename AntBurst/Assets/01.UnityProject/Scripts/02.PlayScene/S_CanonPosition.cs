using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CanonPosition : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 mousePosition = default;
    Vector3 mousePosition3D =default;
    GameObject canon = default;
    GameObject backBoard = default;
    void Start()
    {
        canon = Resources.Load("Prefabs/Canon") as GameObject;
        backBoard = GameObject.Find("BackGround");
    }

    void OnEnable()
    {

    }
    void Update()
    {
        FollowMousePostion();
        
    }

    //! 마우스포지션을 따라가는 함수
    void FollowMousePostion()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       transform.position = mousePosition;
       // { 마우스 왼쪽 버튼을 누르면 캐논이 생성된다.
       if(Input.GetMouseButtonDown(0))
       {
         mousePosition3D.x = mousePosition.x;
         mousePosition3D.y = mousePosition.y;
         mousePosition3D.z = 0;
         Instantiate(canon,mousePosition3D,Quaternion.identity,backBoard.transform);
         GameManager.Instance.SpendMoney();
         gameObject.SetActive(false);
       }
       // } 마우스 왼쪽 버튼을 누르면 캐논이 생성된다.

    }
}
