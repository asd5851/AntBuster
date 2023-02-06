using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S_Cake : MonoBehaviour
{
    public int cakePiece = default;
    public Sprite[] cakeImgs = default;
    // Start is called before the first frame update
    void Start()
    {
        cakePiece = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ant")
        {
            cakePiece--;
            gameObject.GetComponent<Image>().sprite = cakeImgs[8-cakePiece];
        }
    }
}
