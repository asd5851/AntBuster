using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_CanonImg : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    //public RectTransform transform_cursor;
    public RectTransform transform_icon;
    //public Text text_mouse;
    private S_SubZone subZone = default;

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.AddAnchorPos(
                eventData.delta / subZone.parentCanvas.scaleFactor);
        
            // 캔버스 scaleFactor 만큼 발생하는 오차를 수정하는 로직
            //gameObject.AddAnchorPos(
                //eventData.delta / Canvas.scaleFactor);
             // if : 현재 오브젝트를 선택한 경우
    }
    private void Start()
    {
        subZone = transform.parent.
            gameObject.GetComponentMust<S_SubZone>();
        //Init_Cursor();
    }
    private void Update()
    {
       
        transform_icon.anchoredPosition = Input.mousePosition / subZone.parentCanvas.scaleFactor;
        //Update_MousePosition();
    }

    private void Init_Cursor()
    {
        Cursor.visible = false;
        // transform_cursor.pivot = Vector2.up;

        // if (transform_cursor.GetComponent<Graphic>())
        //     transform_cursor.GetComponent<Graphic>().raycastTarget = false;
        if (transform_icon.GetComponent<Graphic>())
            transform_icon.GetComponent<Graphic>().raycastTarget = false;
    }

    //CodeFinder 코드파인더
    //From https://codefinder.janndk.com/ 
    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
       // transform_cursor.position = mousePos;
        float w = transform_icon.rect.width;
        float h = transform_icon.rect.height;
        transform_icon.position = transform_icon.position + (new Vector3(w, h) * 0.5f);

        string message = mousePos.ToString();
        //text_mouse.text = message;
        Debug.Log(message);
    }
    private void OnMouseEnter()
    {
        gameObject.FindChildObj("CanonStatsBack").SetActive(true);
        Debug.Log("마우스위에잇음");
    }
    private void OnMouseExit()
    {
        gameObject.FindChildObj("CanonStatsBack").SetActive(false);
        Debug.Log("마우스위에없음");
    }
    void OnClickIcon()
    {

    }

}
