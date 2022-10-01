using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileCountTexts : MonoBehaviour {
    public TMP_Text p1big, p1mid, p1small, p2big, p2mid, p2small;
    void Update() {
        p1big.text = GameManager.P1Big.ToString();
        p1mid.text = GameManager.P1Mid.ToString();
        p1small.text = "\u221E";
        p2big.text = GameManager.P2Big.ToString();
        p2mid.text = GameManager.P2Mid.ToString();
        p2small.text = "\u221E";
    }
}
