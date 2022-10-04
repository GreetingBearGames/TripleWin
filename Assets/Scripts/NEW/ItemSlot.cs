using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;

            StartCoroutine(RaycastPasiflestirici(eventData.pointerDrag));
        }
    }

    public IEnumerator RaycastPasiflestirici(GameObject obje)
    {
        yield return new WaitForEndOfFrame();
        obje.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Debug.Log(obje.name + " / " + this.name);
    }

}
