using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    private GameObject tile;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "P1Big" || other.gameObject.tag == "P2Big" ||
            other.gameObject.tag == "P1Medium" || other.gameObject.tag == "P2Medium" ||
            other.gameObject.tag == "P1Small" || other.gameObject.tag == "P2Small") {
            SetTile(other.gameObject);
            if (GetCell() != null)
                Debug.Log("Cell : " + GetCell().transform.name);
            if (GetTile() != null)
                Debug.Log("Tile : " + GetTile().transform.name);
        }
    }

    private void SetTile(GameObject go) {
        tile = go;
    }
    public GameObject GetTile() {
        return tile;
    }
    public GameObject GetCell() {
        return this.gameObject;
    }
}
