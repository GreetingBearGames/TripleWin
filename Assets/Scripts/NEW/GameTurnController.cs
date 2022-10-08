using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTurnController : MonoBehaviour
{
    [SerializeField] GameObject notPlacedP1Items, notPlacedP2Items, p1Text, p2Text;
    public int turnNumber;  //1 ise sıra 1 e geçti. 2 ise sıra 2 ye geçti.


    private void Start()
    {
        turnNumber = 1;
        TurnSwap();
    }


    public void TurnSwap()
    {
        if (turnNumber == 1)
        {
            var image = p1Text.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

            image = p2Text.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);


            for (int i = 0; i < notPlacedP1Items.transform.childCount; i++)
            {
                var p1item = notPlacedP1Items.transform.GetChild(i);
                var p1ItemImage = p1item.GetComponent<Image>();
                p1ItemImage.color = new Color(p1ItemImage.color.r, p1ItemImage.color.g, p1ItemImage.color.b, 1f);
                p1item.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }

            for (int i = 0; i < notPlacedP2Items.transform.childCount; i++)
            {
                var p2item = notPlacedP2Items.transform.GetChild(i);
                var p2ItemImage = p2item.GetComponent<Image>();
                p2ItemImage.color = new Color(p2ItemImage.color.r, p2ItemImage.color.g, p2ItemImage.color.b, 0.3f);
                p2item.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }

            turnNumber = 2;
            return;
        }

        if (turnNumber == 2)
        {
            var image = p2Text.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

            image = p1Text.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);


            for (int i = 0; i < notPlacedP2Items.transform.childCount; i++)
            {
                var p2item = notPlacedP2Items.transform.GetChild(i);
                var p2ItemImage = p2item.GetComponent<Image>();
                p2ItemImage.color = new Color(p2ItemImage.color.r, p2ItemImage.color.g, p2ItemImage.color.b, 1f);
                p2item.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }

            for (int i = 0; i < notPlacedP1Items.transform.childCount; i++)
            {
                var p1item = notPlacedP1Items.transform.GetChild(i);
                var p1ItemImage = p1item.GetComponent<Image>();
                p1ItemImage.color = new Color(p1ItemImage.color.r, p1ItemImage.color.g, p1ItemImage.color.b, 0.3f);
                p1item.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }

            turnNumber = 1;
            return;
        }
    }
}
