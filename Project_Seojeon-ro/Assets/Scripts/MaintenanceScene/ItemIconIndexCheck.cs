using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//아이템 아이콘의 인덱스를 체크하는 클래스
public class ItemIconIndexCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    UIController_Maintenance uiController;

    void Start()
    {
        uiController = FindObjectOfType<UIController_Maintenance>();

        if(uiController == null)
            LogHandler.WriteLog("UIController_Maintenance를 찾을 수 없습니다.", this.GetType().Name, LogType.Error, true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < uiController.InventoryImages.Length; i++)
        {
            if (uiController.InventoryImages[i].gameObject == gameObject)
            {
                uiController.UpdateItemDescriptionUI(i, true);
                return;
            }
        }

        uiController.UpdateItemDescriptionUI(-1, false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiController.UpdateItemDescriptionUI(-1, false);
    }
}
