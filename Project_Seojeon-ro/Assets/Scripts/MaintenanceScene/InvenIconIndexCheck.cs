using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//������ �������� �ε����� üũ�ϴ� Ŭ����
public class InvenIconIndexCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    UIController_Maintenance uiController;

    void Start()
    {
        uiController = FindObjectOfType<UIController_Maintenance>();

        if(uiController == null)
            LogHandler.WriteLog("UIController_Maintenance�� ã�� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int _index = -1;
        bool _isActivated = false;

        for (int i = 0; i < uiController.InventoryImages.Length; i++)
        {
            if (uiController.InventoryImages[i].gameObject == gameObject)
            {
                _index = i;
                _isActivated = true;

                uiController.UpdateItemDescriptionUI(_index, _isActivated, true);
                break;
            }
        }

        for(int i = 0; i < uiController.EquipImages.Length; i++)
        {
            if (uiController.EquipImages[i].gameObject == gameObject)
            {
                _index = i;
                _isActivated = true;

                uiController.UpdateItemDescriptionUI(_index, _isActivated, false);
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiController.UpdateItemDescriptionUI(-1, false);
    }
}
