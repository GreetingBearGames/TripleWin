using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public void P1Big() {
        if (GameManager.P1Big > 0) {
            GameManager.IsSelectedP1Big = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Mid = false;
            GameManager.IsSelectedP2Small = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P1Mid() {
        if (GameManager.P1Mid > 0) {
            GameManager.IsSelectedP1Mid = true;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Mid = false;
            GameManager.IsSelectedP2Small = false;

        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P1Mid2() {
        if (GameManager.P1Mid > 0) {
            GameManager.IsSelectedP1Mid = true;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Mid = false;
            GameManager.IsSelectedP2Small = false;

        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P1Small() {
        if (GameManager.P1Small > 0) {
            GameManager.IsSelectedP1Small = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Mid = false;
            GameManager.IsSelectedP2Small = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P2Big() {
        if (GameManager.P2Big > 0) {
            GameManager.IsSelectedP2Big = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Mid = false;
            GameManager.IsSelectedP2Small = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P2Mid() {
        if (GameManager.P2Mid > 0) {
            GameManager.IsSelectedP2Mid = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Small = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P2Mid2() {
        if (GameManager.P2Mid > 0) {
            GameManager.IsSelectedP2Mid = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Small = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void P2Small() {
        if (GameManager.P2Small > 0) {
            GameManager.IsSelectedP2Small = true;
            GameManager.IsSelectedP1Mid = false;
            GameManager.IsSelectedP1Big = false;
            GameManager.IsSelectedP1Small = false;
            GameManager.IsSelectedP2Big = false;
            GameManager.IsSelectedP2Mid = false;
        } else
            Debug.Log("Taş kalmadı, başka taş dene!");
    }
    public void Restart() {
        SceneManager.LoadScene(0);
        this.transform.parent.GetChild(9).gameObject.SetActive(false);
    }
}
