using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText, p2ScoreText;
    [SerializeField] WinController winController;
    [SerializeField] GameObject p1MedPrefab, p2MedPrefab;
    private Transform p1MediumParent, p2MediumParent;
    private Vector3 p1MedPos, p2MedPos;
    [SerializeField] GameObject explosionParticle, scoreLineParticle;
    private bool scoreVarMi;
    [SerializeField] GameTurnController gameTurnController;

    void Start()
    {
        GameObject p1MedInScene = GameObject.FindWithTag("P1Med");
        p1MediumParent = p1MedInScene.transform.parent;
        p1MedPos = p1MedInScene.transform.position;

        GameObject p2MedInScene = GameObject.FindWithTag("P2Med");
        p2MediumParent = p2MedInScene.transform.parent;
        p2MedPos = p2MedInScene.transform.position;
    }


    public void CheckScore(int num)
    {
        scoreVarMi = false;

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

        if (!scoreVarMi) gameTurnController.TurnSwap();
    }

    IEnumerator P1Score(int toplam, int item1Place, int item2Place, int item3Place)
    {
        scoreVarMi = true;
        yield return new WaitForSeconds(0.2f);
        //1-score line particle'ı oynayacak
        Vector3 scoreYonu = TablaSlotController.Current.slottakiObjeArr[item3Place].transform.position - TablaSlotController.Current.slottakiObjeArr[item1Place].transform.position;
        float angle = Vector3.Angle(scoreYonu, transform.up);
        Quaternion scoreAcisi = Quaternion.Euler(0, 0, angle);
        Instantiate(scoreLineParticle, TablaSlotController.Current.slottakiObjeArr[item1Place].transform.position, scoreAcisi);
        //111111111111111111111111111111111111

        yield return new WaitForSeconds(0.4f);
        //2-slotlardaki objeler yok edilecek
        Destroy(TablaSlotController.Current.slottakiObjeArr[item1Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item2Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item3Place]);
        TablaSlotController.Current.slottakiItemArr[item1Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item2Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item3Place] = 0;
        //222222222222222222222222222222222222

        yield return new WaitForSeconds(0.2f);
        //3-score tablosunda patlama olacak.
        Instantiate(explosionParticle, p1ScoreText.gameObject.transform);
        //333333333333333333333333333333333333

        //4-score tablosunda artış olacak.
        yield return new WaitForSeconds(0.5f);
        p1ScoreText.text = (int.Parse(p1ScoreText.text) + 1).ToString();
        //444444444444444444444444444444444444

        yield return new WaitForSeconds(0.1f);
        //5-orta hediye etme durumu sorgulanacak
        if (Mathf.Abs(toplam) == 7)     //1 büyük 2 orta ile sayı yapılırsa 1 orta hediye et.
        {
            Instantiate(explosionParticle, p1MedPos, Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            Instantiate(p1MedPrefab, p1MedPos, Quaternion.identity, p1MediumParent);
        }
        //555555555555555555555555555555555555

        yield return new WaitForSeconds(0.1f);
        CheckWin(p1ScoreText.text, "p1");
    }

    IEnumerator P2Score(int toplam, int item1Place, int item2Place, int item3Place)
    {
        scoreVarMi = true;
        yield return new WaitForSeconds(0.2f);
        //1-score line particle'ı oynayacak
        Vector3 scoreYonu = TablaSlotController.Current.slottakiObjeArr[item3Place].transform.position - TablaSlotController.Current.slottakiObjeArr[item1Place].transform.position;
        float angle = Vector3.Angle(scoreYonu, transform.up);
        Quaternion scoreAcisi = Quaternion.Euler(0, 0, angle);
        Instantiate(scoreLineParticle, TablaSlotController.Current.slottakiObjeArr[item1Place].transform.position, scoreAcisi);
        //111111111111111111111111111111111111

        yield return new WaitForSeconds(0.4f);
        //2-slotlardaki objeler yok edilecek
        Destroy(TablaSlotController.Current.slottakiObjeArr[item1Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item2Place]);
        Destroy(TablaSlotController.Current.slottakiObjeArr[item3Place]);
        TablaSlotController.Current.slottakiItemArr[item1Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item2Place] = 0;
        TablaSlotController.Current.slottakiItemArr[item3Place] = 0;
        //222222222222222222222222222222222222

        yield return new WaitForSeconds(0.2f);
        //3-score tablosunda patlama olacak.
        Instantiate(explosionParticle, p2ScoreText.gameObject.transform);
        //333333333333333333333333333333333333

        //4-score tablosunda artış olacak.
        yield return new WaitForSeconds(0.5f);
        p2ScoreText.text = (int.Parse(p2ScoreText.text) + 1).ToString();
        //444444444444444444444444444444444444

        yield return new WaitForSeconds(0.2f);
        //5-orta hediye etme durumu sorgulanacak
        if (Mathf.Abs(toplam) == 7)     //1 büyük 2 orta ile sayı yapılırsa 1 orta hediye et.
        {
            Instantiate(explosionParticle, p2MedPos, Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            Instantiate(p2MedPrefab, p2MedPos, Quaternion.identity, p2MediumParent);
        }
        //555555555555555555555555555555555555

        yield return new WaitForSeconds(0.1f);
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
        else { gameTurnController.TurnSwap(); }
    }



    private void xSagaDogru(int num)    //x ekseninde sayı. en sola konuldu. sağa doğru 3lü oldu
    {
        if (num % 5 <= 2)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 1];
            int c = TablaSlotController.Current.slottakiItemArr[num + 2];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num + 2, num + 1, num));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num + 2, num + 1, num));
        }
    }
    private void xSolaDogru(int num)    //x ekseninde sayı. en sağa konuldu. sola doğru 3lü oldu
    {
        if (num % 5 >= 2)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 1];
            int c = TablaSlotController.Current.slottakiItemArr[num - 2];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num, num - 1, num - 2));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num, num - 1, num - 2));
        }
    }
    private void xOrta(int num)    //x ekseninde sayı. ortaya konuldu. ortada 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 1];
            int c = TablaSlotController.Current.slottakiItemArr[num + 1];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num + 1, num, num - 1));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num + 1, num, num - 1));
        }
    }
    private void yAsagiDogru(int num)    //y ekseninde sayı. en yukarı konuldu. aşağı doğru 3lü oldu
    {
        if (num <= 14)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 5];
            int c = TablaSlotController.Current.slottakiItemArr[num + 10];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num, num + 5, num + 10));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num, num + 5, num + 10));
        }
    }
    private void yYukariDogru(int num)    //y ekseninde sayı. en aşağı konuldu. yukarı doğru 3lü oldu
    {
        if (num >= 10)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 5];
            int c = TablaSlotController.Current.slottakiItemArr[num - 10];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num, num - 5, num - 10));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num, num - 5, num - 10));
        }
    }
    private void yOrta(int num)    //y ekseninde sayı. ortaya konuldu. ortada 3lü oldu
    {
        if (num >= 5 && num <= 19)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 5];
            int c = TablaSlotController.Current.slottakiItemArr[num + 5];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num - 5, num, num + 5));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num - 5, num, num + 5));
        }
    }
    private void xySagCaprazAsagiyaDogru(int num)    //çapraz ekseninde sayı. en sol üste konuldu. aşağı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 <= 2 && num <= 12)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 6];
            int c = TablaSlotController.Current.slottakiItemArr[num + 12];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num + 12, num + 6, num));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num + 12, num + 6, num));
        }
    }
    private void xySolCaprazYukariyaDogru(int num)    //çapraz ekseninde sayı. en sağ alta konuldu. yukarı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 2 && num >= 12)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 6];
            int c = TablaSlotController.Current.slottakiItemArr[num - 12];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num, num - 6, num - 12));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num, num - 6, num - 12));
        }
    }
    private void xySagCaprazAsagiyaOrta(int num)    //çapraz ekseninde sayı. ortaya konuldu.  aşağı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3 && num >= 6 && num <= 18)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 6];
            int c = TablaSlotController.Current.slottakiItemArr[num + 6];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num + 6, num, num - 6));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num + 6, num, num - 6));
        }
    }
    private void xySolCaprazAsagiyaDogru(int num)    //çapraz ekseninde sayı. en sağ üste konuldu. aşağı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 2 && num <= 14)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 4];
            int c = TablaSlotController.Current.slottakiItemArr[num + 8];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num, num + 4, num + 8));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num, num + 4, num + 8));
        }
    }
    private void xySagCaprazYukariyaDogru(int num)    //çapraz ekseninde sayı. en sol alta konuldu. yukarı sağ çapraza doğru 3lü oldu
    {
        if (num % 5 <= 2 && num >= 10)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num - 4];
            int c = TablaSlotController.Current.slottakiItemArr[num - 8];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num - 8, num - 4, num));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num - 8, num - 4, num));
        }
    }
    private void xySolCaprazAsagiyaOrta(int num)    //çapraz ekseninde sayı. ortaya konuldu.  aşağı sol çapraza doğru 3lü oldu
    {
        if (num % 5 >= 1 && num % 5 <= 3 && num >= 6 && num <= 18)
        {
            int a = TablaSlotController.Current.slottakiItemArr[num];
            int b = TablaSlotController.Current.slottakiItemArr[num + 4];
            int c = TablaSlotController.Current.slottakiItemArr[num - 4];

            if (a > 0 && b > 0 && c > 0) StartCoroutine(P1Score(a + b + c, num - 4, num, num + 4));
            else if (a < 0 && b < 0 && c < 0) StartCoroutine(P2Score(a + b + c, num - 4, num, num + 4));
        }
    }
}
















