using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    [SerializeField] GameObject winMenu;

    void Start()
    {

    }

    void Update()
    {

    }

    public void P1Win()
    {
        StartCoroutine(winScreenAcilis(0));
    }

    public void P2Win()
    {
        StartCoroutine(winScreenAcilis(1));
    }

    private IEnumerator winScreenAcilis(int value)
    {
        winMenu.transform.GetChild(value).transform.gameObject.SetActive(true);

        while (winMenu.transform.GetChild(value).GetComponent<Image>().color.a < 1)
        {
            Color clr = winMenu.transform.GetChild(value).GetComponent<Image>().color;
            clr.a += 0.05f;
            winMenu.transform.GetChild(value).GetComponent<Image>().color = clr;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        winMenu.transform.GetChild(2).transform.gameObject.SetActive(true);
        winMenu.transform.GetChild(3).transform.gameObject.SetActive(true);
    }
}
