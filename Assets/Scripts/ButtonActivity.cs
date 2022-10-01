using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivity : MonoBehaviour {
    public Button p1big, p2big, p1mid, p2mid, p1small, p2small, p1mid2, p2mid2;
    private void Update() {
        if (GameManager.playerTurn) {
            p1big.interactable = false;
            p1mid.interactable = false;
            p1mid2.interactable = false;
            p1small.interactable = false;
            p2big.interactable = true;
            p2mid.interactable = true;
            p2mid2.interactable = true;
            p2small.interactable = true;

        } else {
            p1big.interactable = true;
            p1mid.interactable = true;
            p1mid2.interactable = true;
            p1small.interactable = true;
            p2big.interactable = false;
            p2mid.interactable = false;
            p2mid2.interactable = false;
            p2small.interactable = false;
        }
        if (GameManager.P1Win) {
            StartCoroutine(WaitaLittle1());
            
        } else if (GameManager.P2Win) {
            StartCoroutine(WaitaLittle2());
        }
    }
    IEnumerator WaitaLittle1(){
        yield return new WaitForSeconds(4f);
        this.transform.GetChild(8).gameObject.SetActive(true);
        this.transform.GetChild(8).transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(9).gameObject.SetActive(true);
        this.transform.GetChild(10).gameObject.SetActive(false);
        this.transform.GetChild(11).gameObject.SetActive(false);
    }
    IEnumerator WaitaLittle2(){
        yield return new WaitForSeconds(4f);
        this.transform.GetChild(8).gameObject.SetActive(true);
        this.transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(9).gameObject.SetActive(true);
        this.transform.GetChild(10).gameObject.SetActive(false);
        this.transform.GetChild(11).gameObject.SetActive(false);
    }

}
