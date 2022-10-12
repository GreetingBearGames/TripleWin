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
        switch (slotaNeYerlesti.Substring(0, 5))
        {
            case "P1Big":
                slotaYerlesenItem = 3;
                break;
            case "P1Med":
                slotaYerlesenItem = 2;
                break;
            case "P1Sma":
                slotaYerlesenItem = 1;
                break;
            case "P2Big":
                slotaYerlesenItem = -3;
                break;
            case "P2Med":
                slotaYerlesenItem = -2;
                break;
            case "P2Sma":
                slotaYerlesenItem = -1;
                break;
        }

        return slotaYerlesenItem;
    }

}
