using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablaSlotController : MonoBehaviour
{
    [SerializeField] RectTransform boyutlandirilmisTabla;

    void Start()
    {
        StartCoroutine(TablaveSlotBoyutlandirici());
    }

    void Update()
    {

    }

    public IEnumerator TablaveSlotBoyutlandirici()
    {
        yield return new WaitForEndOfFrame();

        GetComponent<RectTransform>().sizeDelta = boyutlandirilmisTabla.sizeDelta;
        transform.position = boyutlandirilmisTabla.gameObject.transform.position;

        this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(this.GetComponent<RectTransform>().rect.width / 5, this.GetComponent<RectTransform>().rect.height / 5);
    }
}
