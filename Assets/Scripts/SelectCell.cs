using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCell : MonoBehaviour {
    public static int siblingIndex, tileSize; //tileSize 0 = empty, 1 = small, 2 = mid, 3 = big
    public static bool updateGameBoard;
    private void ClickSelect() {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit) {
            if (GameManager.IsSelectedP1Big) {
                tileSize = 3;
                GameManager.IsP1 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            } else if (GameManager.IsSelectedP1Mid) {
                tileSize = 2;
                GameManager.IsP1 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            } else if (GameManager.IsSelectedP1Small) {
                tileSize = 1;
                GameManager.IsP1 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            } else if (GameManager.IsSelectedP2Big) {
                tileSize = 3;
                GameManager.IsP2 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            } else if (GameManager.IsSelectedP2Mid) {
                tileSize = 2;
                GameManager.IsP2 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            } else if (GameManager.IsSelectedP2Small) {
                tileSize = 1;
                GameManager.IsP2 = true;
                siblingIndex = hit.transform.GetSiblingIndex();
                updateGameBoard = true;
            }
        }
    }
    void OnMouseDown() {
        ClickSelect();
    }
}
