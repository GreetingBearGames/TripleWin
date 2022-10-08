using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablaSlotController : MonoBehaviour
{
    public static TablaSlotController Current;
    [SerializeField] RectTransform boyutlandirilmisTabla;
    public int[] slottakiItemArr = new int[25];
    private GameObject[] slottakiObjeArr = new GameObject[25];
    [SerializeField] GameTurnController gameTurnController;
    [SerializeField] GameObject p1particle, p2particle;

    void Start()
    {
        Current = this;
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


    public void HangiItemiBirakti(int hangiSlot, int hangiItem, GameObject itemObjesi, GameObject slotObjesi)
    {
        //----------- P1Small-->1,P1Medium-->2,P1Big-->3   &&   P2Small-->-1,P2Medium-->-2,P2Big-->-3    ---------------

        if (slottakiItemArr[hangiSlot] == 0)    //eğer ilgili tablo slotunda hiçbir item yoksa
        {
            itemObjesi.transform.position = slotObjesi.transform.position;

            slottakiItemArr[hangiSlot] = hangiItem;
            slottakiObjeArr[hangiSlot] = itemObjesi;

            StartCoroutine(ItemPasiflestiriciVEturSonladrici(itemObjesi));
        }
        else if (Mathf.Sign(slottakiItemArr[hangiSlot]) == Mathf.Sign(hangiItem))   //eğer kendi taşı üstüne bindirirse(aynı renk taş üstüste olursa)
        {
            itemObjesi.transform.position = itemObjesi.GetComponent<DragandDrop>().startPos;
        }
        else if (Mathf.Abs(slottakiItemArr[hangiSlot]) >= Mathf.Abs(hangiItem))    //eğer ilgili tablo slotundaki item, yenisiyle eşit veya daha güçlüyse
        {
            itemObjesi.transform.position = itemObjesi.GetComponent<DragandDrop>().startPos;
        }
        else    //eğer ilgili tablo slotundaki item, yenisinden güçsüzse
        {
            Debug.Log("üstüme yap");


            StartCoroutine(ItemYokediciVEturSonladrici(hangiItem, itemObjesi, hangiSlot, slotObjesi));
        }
    }



    private IEnumerator ItemPasiflestiriciVEturSonladrici(GameObject yeniKonulanObje)
    {
        yield return new WaitForEndOfFrame();
        yeniKonulanObje.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //yerleştirilen objeyi Not Placed parentinden Placed parentine koymak.
        var placedItemsObject = yeniKonulanObje.transform.parent.gameObject.transform.parent.GetChild(0);
        yeniKonulanObje.transform.SetParent(placedItemsObject, true);

        gameTurnController.TurnSwap();
    }


    private IEnumerator ItemYokediciVEturSonladrici
        (int slotaYerlesenItem, GameObject yeniKonulanObje, int slotNumarasi, GameObject slotObjesi)
    {
        yield return new WaitForEndOfFrame();
        ParticleDogurucu(slottakiItemArr[slotNumarasi], slottakiObjeArr[slotNumarasi].transform.position, slotaYerlesenItem);
        yield return new WaitForEndOfFrame();
        Destroy(slottakiObjeArr[slotNumarasi]);


        yield return new WaitForEndOfFrame();
        yeniKonulanObje.transform.position = slotObjesi.transform.position;

        slottakiItemArr[slotNumarasi] = slotaYerlesenItem;
        slottakiObjeArr[slotNumarasi] = yeniKonulanObje;


        //yerleştirilen objeyi Not Placed parentinden Placed parentine koymak.
        var placedItemsObject = yeniKonulanObje.transform.parent.gameObject.transform.parent.GetChild(0);
        yeniKonulanObje.transform.SetParent(placedItemsObject, true);

        yeniKonulanObje.GetComponent<CanvasGroup>().blocksRaycasts = false;

        gameTurnController.TurnSwap();

        /*
        switch (slottakiItem)
        {
            case 1:
                if (slotaYerlesenItem == -2)
                {
                    ParticleDogurucu(slottakiItem, slottakiObje.transform, slotaYerlesenItem);
                }
                break;
            case 2:

                break;
            case -1:

                break;
            case -2:

                break;
        }
        */










        //İLGİLİ SLOTTA VAR OLAN OBJE BOYUTUNA GÖRE PARTİCLE INSTAN








    }

    private void ParticleDogurucu(int slottakiItem, Vector3 slottakiObjePos, int slotaYerlesenItem)
    {
        int particleSize = Mathf.Abs(slotaYerlesenItem) * 20;
        if (Mathf.Sign(slottakiItem) == 1) //eğer pozitifse. Yani slottaki yok edilecek item player1'e aitse
        {
            var particleGameObject = p1particle;

            particleGameObject.transform.localScale = p1particle.transform.localScale * particleSize;
            Instantiate(particleGameObject, slottakiObjePos, p1particle.transform.rotation);
        }
        else
        {
            p2particle.transform.localScale = p2particle.transform.localScale * particleSize;
            Instantiate(p2particle, slottakiObjePos, p2particle.transform.rotation);
        }
    }

}
