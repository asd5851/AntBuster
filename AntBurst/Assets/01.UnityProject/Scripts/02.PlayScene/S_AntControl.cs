using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S_AntControl : MonoBehaviour
{
    private GameObject cake;
    private GameObject antSpawn;
    public Sprite []antImg = default;
    int hp = 10;
    float delay_cur = 0f;
    float delay_max = 3f;
    public int HP
    {
        get
        {
            return hp;
        }
    }

    bool goWhere = false;
    // Start is called before the first frame update
    void Awake()
    {
        antSpawn = GameObject.Find("AntSpawn");
        cake = GameObject.Find("Cake");
    }
    void OnEnable()
    {
        hp = 10;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!goWhere)
        {        
            MoveCake();
        }
        else{
            MoveSpawn();
        }
    }
    //! 개미가 케이크로 움직인다.
    void MoveCake()
    {
        
        int randMove = Random.Range(0,6);
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
        //myTransform.Translate(moveAmount);
        Debug.Log(randMove);
        if(randMove <= 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, cake.transform.position, Time.deltaTime);
        }
        else if(randMove >= 4)
        {
            transform.Translate(Vector3.up*Time.deltaTime);
        }
        else if(randMove == 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.left, Time.deltaTime);
        }
       //transform.position = Vector2.MoveTowards(transform.position, Vector2.up, Time.deltaTime);
    }

    //! 개미가 스폰지점으로 움직인다.
    void MoveSpawn()
    {
        transform.position = Vector3.MoveTowards(transform.position, antSpawn.transform.position, Time.deltaTime);
    }

    //! 개미가 다른 오브젝트를 만났을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        // 케이크를 만났을 때
        if(other.gameObject.tag == "Cake")
        {
            goWhere = true;
            // 개미의 이미지 변경한다.
            gameObject.GetComponent<Image>().sprite = antImg[1];
        }
        // 개미구멍을 만났을 때
        else if(other.gameObject.tag == "AntSpawn")
        {
            Debug.Log("만낫니");
            // 개미의 이미지를 변경한다.
            gameObject.GetComponent<Image>().sprite = antImg[0];
            goWhere = false;
        }
        // 총알을 만났을 때
        else if(other.gameObject.tag == "Bullet")
        {
            hp -= other.GetComponent<S_BulletMove>().bulletDamage;
            Debug.Log($"hp = {hp}");
            if(hp<=0)
            {
                ObjectPoolingAnt.ReturnObject(gameObject);
                GameManager.Instance.GetScore();
                GameManager.Instance.GetMoney();
            }
        }
    }
}
