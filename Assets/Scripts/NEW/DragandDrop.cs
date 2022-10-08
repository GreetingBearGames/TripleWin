using UnityEngine;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public Vector2 startPos;
    private GameObject boyutlandirilmisTabla;


    void Start()
    {
        boyutlandirilmisTabla = GameObject.Find("2-Tabla");
        canvasGroup = this.GetComponent<CanvasGroup>();
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = transform.position;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;     //böylece tutup sürüklenemez yaptın.
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;     //böylece tekrar tutup sürüklenebilir yaptın.


        //tabla haricinde bir yere sürüklerse
        if (!RectTransformUtility.RectangleContainsScreenPoint(boyutlandirilmisTabla.GetComponent<RectTransform>(), rectTransform.position))
        {
            transform.position = startPos;
        }
    }
}
