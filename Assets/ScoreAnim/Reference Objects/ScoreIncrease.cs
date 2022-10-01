using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour
{
    private Text pScore;

    public void ScoreIncreasewithFade(int whichPlayerScore)
    {
        pScore = ((transform.GetChild(0).transform).transform.GetChild(whichPlayerScore).transform).GetComponent<Text>();
        StartCoroutine(WaitaLittle(pScore));
    }


    IEnumerator WaitaLittle(Text whichPlayerScore)
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().Play("Fadein");
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        whichPlayerScore.text = (int.Parse(whichPlayerScore.text) + 1).ToString();

        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.SetActive(false);
        this.GetComponent<Animator>().Play("Fadeout");
        this.gameObject.GetComponent<Image>().enabled = false;
    }
}
