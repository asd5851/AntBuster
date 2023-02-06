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
    GameObject canonPosition = default;

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
        
    }
    private void Update()
    {
       
        //transform_icon.anchoredPosition = Input.mousePosition / subZone.parentCanvas.scaleFactor;
    }

    private void OnMouseEnter()
    {
        gameObject.FindChildObj("CanonStatsBack").SetActive(true);
    }
    private void OnMouseExit()
    {
        gameObject.FindChildObj("CanonStatsBack").SetActive(false);
    }

    //! 이미지 클릭시
    public void OnClickIcon()
    {
        // { 캐논 오브젝트의 이미지가 마우스를 따라다닌다
        canonPosition = GameObject.Find("GameObjs").FindChildObj("CanonPostionObj");
        canonPosition.SetActive(true);
        // } 캐논 오브젝트의 이미지가 마우스를 따라다닌다

    }

}
