using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText, p2ScoreText;
    [SerializeField] WinController winController;
    [SerializeField] GameObject p1Medium, p2Medium;
    private Transform p1MediumParent, p2MediumParent;
    private Vector3 p1MedPos, p2MedPos;

    void Start()
    {
        p1Medium = GameObject.FindWithTag("P1Med");
        p1MediumParent = p1Medium.transform.parent;
        p1MedPos = p1Medium.transform.position;

        p2Medium = GameObject.FindWithTag("P2Med");
        p2MediumParent = p2Medium.transform.parent;
        p2MedPos = p2Medium.transform.position;
    }

    void Update()
    {

    }

    public void CheckScore(int num)
    {
        xSagaDogru(num);
        xSolaDogru(num);
        xOrta(num);
        yAsagiDogru(num);
        yYukariDogru(num);
        yOrta(num);
        xySagCaprazAsagiyaDogru(num);
        xySolCaprazYukariyaDogru(num);
        xySagCaprazAsagiyaOrta(num);
        xySolCaprazAsagiyaDogru(num);
        xySagCaprazYukariyaDogru(num);
        xySolCaprazAsagiyaOrta(num);
    }

    private void P1Score(int toplam, int item1Place, int item2Place, int item3Place)
    {
        //1 büyük 2 orta ile sayı yapılırsa 1 orta hediye et.
        if (Mathf.Abs(toplam) == 7)
        {
            Instantiate(p1Medium, p1MedPos, Quaternion.identity, p1MediumParent);
        }
        //-----------------


        //slottaki objeleri yok etme
        Destroy(TablaSlotController.Current.slottakiObjeArr[item1Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item2Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item3Place]);
        TablaSlotController.Current.slottakiItemArr[item1Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item2Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item3Place] = 0;
        //------------------


        Debug.Log("p1 score");
        p1ScoreText.text = (int.Parse(p1ScoreText.text) + 1).ToString();
        CheckWin(p1ScoreText.text, "p1");
    }

    private void P2Score(int toplam, int item1Place, int item2Place, int item3Place)
    {
        //1 büyük 2 orta ile sayı yapılırsa 1 orta hediye et.
        if (Mathf.Abs(toplam) == 7)
        {
            Instantiate(p2Medium, p2MedPos, Quaternion.identity, p2MediumParent);
        }
        //-----------------


        //slottaki objeleri yok etme
        Destroy(TablaSlotController.Current.slottakiObjeArr[item1Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item2Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item3Place]);
        TablaSlotController.Current.slottakiItemArr[item1Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item2Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item3Place] = 0;
        //------------------


        Debug.Log("p2 score");
        p2ScoreText.text = (int.Parse(p2ScoreText.text) + 1).ToString();
        CheckWin(p2ScoreText.text, "p2");
    }

    private void CheckWin(string oyuncuScore, string hangiOyuncu)
    {
        if (oyuncuScore == "3")
        {
            if (hangiOyuncu == "p1")
            {
                winController.P1Win();
            }
            else
            {
                winController.P2Win();
            }
        }
    }



    private void xSagaDogru(int num)    //x ekseninde sayı. en sola konuldu. sağa doğru 3lü oldu
    {
        if (num % 5 <= 2)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 1];
            int c = TablaSlotController.Current.slottakiItemArr[num + 2];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num + 1, num + 2);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num + 1, num + 2);
        }
    }
    private void xSolaDogru(int num)    //x ekseninde sayı. en sağa konuldu. sola doğru 3lü oldu
    {
        if (num % 5 >= 2)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 1];
            int c = TablaSlotController.Current.slottakiItemArr[num - 2];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 1, num - 2);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 1, num - 2);
        }
    }
    private void xOrta(int num)    //x ekseninde sayı. ortaya konuldu. ortada 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 1];
            int c = TablaSlotController.Current.slottakiItemArr[num + 1];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 1, num + 1);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 1, num + 1);
        }
    }
    private void yAsagiDogru(int num)    //y ekseninde sayı. en yukarı konuldu. aşağı doğru 3lü oldu
    {
        if (num <= 14)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 5];
            int c = TablaSlotController.Current.slottakiItemArr[num + 10];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num + 5, num + 10);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num + 5, num + 10);
        }
    }
    private void yYukariDogru(int num)    //y ekseninde sayı. en aşağı konuldu. yukarı doğru 3lü oldu
    {
        if (num >= 10)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 5];
            int c = TablaSlotController.Current.slottakiItemArr[num - 10];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 5, num - 10);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 5, num - 10);
        }
    }
    private void yOrta(int num)    //y ekseninde sayı. ortaya konuldu. ortada 3lü oldu
    {
        if (num >= 5 && num <= 19)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 5];
            int c = TablaSlotController.Current.slottakiItemArr[num + 5];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 5, num + 5);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 5, num + 5);
        }
    }
    private void xySagCaprazAsagiyaDogru(int num)    //çapraz ekseninde sayı. en sol üste konuldu. aşağı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 <= 2 && num <= 12)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 6];
            int c = TablaSlotController.Current.slottakiItemArr[num + 12];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num + 6, num + 12);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num + 6, num + 12);
        }
    }
    private void xySolCaprazYukariyaDogru(int num)    //çapraz ekseninde sayı. en sağ alta konuldu. yukarı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 2 && num >= 12)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 6];
            int c = TablaSlotController.Current.slottakiItemArr[num - 12];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 6, num - 12);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 6, num - 12);
        }
    }
    private void xySagCaprazAsagiyaOrta(int num)    //çapraz ekseninde sayı. ortaya konuldu.  aşağı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3 && num >= 6 && num <= 18)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 6];
            int c = TablaSlotController.Current.slottakiItemArr[num + 6];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 6, num + 6);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 6, num + 6);
        }
    }
    private void xySolCaprazAsagiyaDogru(int num)    //çapraz ekseninde sayı. en sağ üste konuldu. aşağı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 2 && num <= 14)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 4];
            int c = TablaSlotController.Current.slottakiItemArr[num + 8];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num + 4, num + 8);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num + 4, num + 8);
        }
    }
    private void xySagCaprazYukariyaDogru(int num)    //çapraz ekseninde sayı. en sol alta konuldu. yukarı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 <= 2 && num >= 10)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 4];
            int c = TablaSlotController.Current.slottakiItemArr[num - 8];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num - 4, num - 8);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num - 4, num - 8);
        }
    }
    private void xySolCaprazAsagiyaOrta(int num)    //çapraz ekseninde sayı. ortaya konuldu.  aşağı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3 && num >= 6 && num <= 18)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 4];
            int c = TablaSlotController.Current.slottakiItemArr[num - 4];

            if (a > 0 && b > 0 && c > 0) P1Score(a + b + c, num, num + 4, num - 4);
            else if (a < 0 && b < 0 && c < 0) P2Score(a + b + c, num, num + 4, num - 4);
        }
    }
}
















