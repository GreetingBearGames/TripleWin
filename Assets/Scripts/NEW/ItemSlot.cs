using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private int slotaYerlesenItem;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            TablaSlotController.Current.HangiItemiBirakti(int.Parse(this.name), slotaNeYerlesti(eventData.pointerDrag.name), eventData.pointerDrag, this.gameObject);
        }

    }


    private int slotaNeYerlesti(string slotaNeYerlesti)
    {
        switch (slotaNeYerlesti)
        {
            case "P1Big":
                slotaYerlesenItem = 3;
                break;
            case "P1Medium":
                slotaYerlesenItem = 2;
                break;
            case "P1Medium2":
                slotaYerlesenItem = 2;
                break;
            case "P1Small":
                slotaYerlesenItem = 1;
                break;
            case "P2Big":
                slotaYerlesenItem = -3;
                break;
            case "P2Medium":
                slotaYerlesenItem = -2;
                break;
            case "P2Medium2":
                slotaYerlesenItem = -2;
                break;
            case "P2Small":
                slotaYerlesenItem = -1;
                break;
        }

        return slotaYerlesenItem;
    }

}
