using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private ScoreIncrease scoreIncrease;
    public GameObject p1particle, p2particle, canvas;
    public List<GameObject> TileList;
    public GameObject[,] objectsInMap = new GameObject[5, 5];

    public class Cell {
        public int tileSize { get; set; }  //3 big, 2 mid, 1 small
        public int player { get; set; }   //1 p1, 2 p2
    }
    public static short P1Big, P1Mid, P1Small, P2Big, P2Mid, P2Small, P1Score, P2Score;
    public static bool IsSelectedP1Big, IsSelectedP1Mid, IsSelectedP1Small,
                        IsSelectedP2Big, IsSelectedP2Mid, IsSelectedP2Small;
    public static bool IsP1, IsP2, playerTurn, P1Win, P2Win, Draw;
    public static Cell[,] gameBoard = new Cell[5, 5];
    public int[] specialMove = new int[3];
    public int specialMoveCount;
    void Start() {
        playerTurn = false;  //false player 1, true player 2
        Draw = false;
        IsP1 = false;
        IsP2 = false;
        P1Win = false;
        P2Win = false;
        P1Big = 1;
        P1Mid = 2;
        P1Small = 25;
        P2Big = 1;
        P2Mid = 2;
        P2Small = 25;
        P1Score = 0;
        P2Score = 0;
        specialMoveCount = 0;
        for (int x = 0; x < 5; x++) {
            for (int y = 0; y < 5; y++) {
                gameBoard[x, y] = new Cell();
                gameBoard[x, y].tileSize = 0;
                gameBoard[x, y].player = 0;
            }
        }
    }
    void Update() {
        UpdateGameBoard();
    }
    void UpdateGameBoard() {
        if (SelectCell.updateGameBoard) {
            var x = SelectCell.siblingIndex / 5;
            var y = SelectCell.siblingIndex % 5;
            var p = 0;
            int tis = SelectCell.tileSize;
            if (IsP1)
                p = 1;
            else
                p = 2;
            if (gameBoard[x, y].tileSize == 0 || (gameBoard[x, y].player != p && tis > gameBoard[x, y].tileSize)) {
                if (gameBoard[x, y].player != p && tis > gameBoard[x, y].tileSize && gameBoard[x, y].tileSize != 0) {
                    var go = GameObject.FindGameObjectWithTag("Background");
                    var cellGo = go.transform.GetChild(SelectCell.siblingIndex);
                    var cellPos = cellGo.transform.position;
                    Destroy(objectsInMap[x, y]);
                    if (objectsInMap[x, y].tag == "P1Medium") {
                        p2particle.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        Instantiate(p2particle, cellPos, p1particle.transform.rotation);
                    } else if (objectsInMap[x, y].tag == "P1Small") {
                        p2particle.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        Instantiate(p2particle, cellPos, p1particle.transform.rotation);
                    } else if (objectsInMap[x, y].tag == "P2Medium") {
                        p1particle.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        Instantiate(p1particle, cellPos, p1particle.transform.rotation);
                    } else if (objectsInMap[x, y].tag == "P2Small") {
                        p1particle.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        Instantiate(p1particle, cellPos, p1particle.transform.rotation);
                    }

                }
                gameBoard[x, y].tileSize = tis;
                gameBoard[x, y].player = p;
                SelectCell.updateGameBoard = false;
                IsP1 = false;
                IsP2 = false;
                IsSelectedP1Big = false;
                IsSelectedP1Mid = false;
                IsSelectedP1Small = false;
                IsSelectedP2Big = false;
                IsSelectedP2Mid = false;
                IsSelectedP2Small = false;
                ShowOnBoard(SelectCell.siblingIndex, x, y);
                playerTurn = !playerTurn;
            }
        }
        if (CheckWin(1)) {
            if (IsSpecialMove()) {
                Debug.Log("special move p1");
                P1Mid++;
                if (P1Mid == 1) {
                    canvas.transform.GetChild(3).gameObject.SetActive(true);
                } else if (P1Mid == 2) {
                    canvas.transform.GetChild(10).gameObject.SetActive(true);
                }
            }
            P1Score++;
            scoreIncrease.ScoreIncreasewithFade(1);
        } else if (CheckWin(2)) {
            if (IsSpecialMove()) {
                Debug.Log("special move p2");
                P2Mid++;
                if (P2Mid == 1) {
                    canvas.transform.GetChild(6).gameObject.SetActive(true);
                } else if (P2Mid == 2) {
                    canvas.transform.GetChild(11).gameObject.SetActive(true);
                }
            }
            P2Score++;
            scoreIncrease.ScoreIncreasewithFade(2);
        }

        if (CheckDraw()) {
            Draw = true;
        }

        if (P1Score == 3) {
            P1Win = true;
        } else if (P2Score == 3) {
            P2Win = true;
        }

    }
    void ShowOnBoard(int siblingIndex, int x, int y) {
        var go = GameObject.FindGameObjectWithTag("Background");
        var cellGo = go.transform.GetChild(siblingIndex);
        var cellPos = cellGo.transform.position;
        if (gameBoard[x, y].tileSize != 0) {
            var tile = TileList[gameBoard[x, y].player * 3 - gameBoard[x, y].tileSize];
            if (tile.tag == "P1Big") {
                P1Big--;
                canvas.transform.GetChild(2).gameObject.SetActive(false);
            } else if (tile.tag == "P1Medium") {
                P1Mid--;
                if (P1Mid == 1)
                    canvas.transform.GetChild(10).gameObject.SetActive(false);
                else
                    canvas.transform.GetChild(3).gameObject.SetActive(false);
            } else if (tile.tag == "P1Small") {
                P1Small--;
            } else if (tile.tag == "P2Big") {
                P2Big--;
                canvas.transform.GetChild(5).gameObject.SetActive(false);
            } else if (tile.tag == "P2Medium") {
                P2Mid--;
                if (P2Mid == 1)
                    canvas.transform.GetChild(11).gameObject.SetActive(false);
                else
                    canvas.transform.GetChild(6).gameObject.SetActive(false);
            } else if (tile.tag == "P2Small") {
                P2Small--;
            }

            objectsInMap[x, y] = Instantiate(tile, cellPos, Quaternion.identity);
        }
    }
    private bool CheckWin(int ch) {
        for (int x = 0; x < 5; x++) {
            for (int y = 0; y < 5; y++) {
                if (y < 3 && gameBoard[x, y].player == ch && gameBoard[x, y + 1].player == ch && gameBoard[x, y + 2].player == ch) {
                    specialMove[0] = gameBoard[x, y].tileSize;
                    specialMove[1] = gameBoard[x, y + 1].tileSize;
                    specialMove[2] = gameBoard[x, y + 2].tileSize;
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    Destroy(objectsInMap[x, y]);
                    Destroy(objectsInMap[x, y + 1]);
                    Destroy(objectsInMap[x, y + 2]);
                    GameBoardReset(gameBoard[x, y]);
                    GameBoardReset(gameBoard[x, y + 1]);
                    GameBoardReset(gameBoard[x, y + 2]);
                    return true;
                }

                if (x < 3 && gameBoard[x, y].player == ch && gameBoard[x + 1, y].player == ch && gameBoard[x + 2, y].player == ch) {
                    specialMove[0] = gameBoard[x, y].tileSize;
                    specialMove[1] = gameBoard[x + 1, y].tileSize;
                    specialMove[2] = gameBoard[x + 2, y].tileSize;
                    Destroy(objectsInMap[x, y]);
                    Destroy(objectsInMap[x + 1, y]);
                    Destroy(objectsInMap[x + 2, y]);
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    GameBoardReset(gameBoard[x, y]);
                    GameBoardReset(gameBoard[x + 1, y]);
                    GameBoardReset(gameBoard[x + 2, y]);
                    return true;
                }


            }
        }
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (i < 3 && j < 3 && gameBoard[i, j].player == ch && gameBoard[i + 1, j + 1].player == ch && gameBoard[i + 2, j + 2].player == ch) {
                    specialMove[0] = gameBoard[i, j].tileSize;
                    specialMove[1] = gameBoard[i + 1, j + 1].tileSize;
                    specialMove[2] = gameBoard[i + 2, j + 2].tileSize;
                    Destroy(objectsInMap[i, j]);
                    Destroy(objectsInMap[i + 1, j + 1]);
                    Destroy(objectsInMap[i + 2, j + 2]);
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    GameBoardReset(gameBoard[i, j]);
                    GameBoardReset(gameBoard[i + 1, j + 1]);
                    GameBoardReset(gameBoard[i + 2, j + 2]);

                    return true;
                }

                if (i > 1 && j < 3 && gameBoard[i, j].player == ch && gameBoard[i - 1, j + 1].player == ch && gameBoard[i - 2, j + 2].player == ch) {
                    specialMove[0] = gameBoard[i, j].tileSize;
                    specialMove[1] = gameBoard[i - 1, j + 1].tileSize;
                    specialMove[2] = gameBoard[i - 2, j + 2].tileSize;
                    Destroy(objectsInMap[i, j]);
                    Destroy(objectsInMap[i - 1, j + 1]);
                    Destroy(objectsInMap[i - 2, j + 2]);
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    GameBoardReset(gameBoard[i, j]);
                    GameBoardReset(gameBoard[i + 1, j + 1]);
                    GameBoardReset(gameBoard[i + 2, j + 2]);
                    return true;
                }

                if (i < 3 && j > 1 && gameBoard[i, j].player == ch && gameBoard[i + 1, j - 1].player == ch && gameBoard[i + 2, j - 2].player == ch) {
                    specialMove[0] = gameBoard[i, j].tileSize;
                    specialMove[1] = gameBoard[i + 1, j - 1].tileSize;
                    specialMove[2] = gameBoard[i + 2, j - 2].tileSize;
                    Destroy(objectsInMap[i, j]);
                    Destroy(objectsInMap[i + 1, j - 1]);
                    Destroy(objectsInMap[i + 2, j - 2]);
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    GameBoardReset(gameBoard[i, j]);
                    GameBoardReset(gameBoard[i + 1, j - 1]);
                    GameBoardReset(gameBoard[i + 2, j - 2]);
                    return true;
                }

                if (i > 1 && j > 1 && gameBoard[i, j].player == ch && gameBoard[i - 1, j - 1].player == ch && gameBoard[i - 2, j - 2].player == ch) {
                    specialMove[0] = gameBoard[i, j].tileSize;
                    specialMove[1] = gameBoard[i - 1, j - 1].tileSize;
                    specialMove[2] = gameBoard[i - 2, j - 2].tileSize;
                    Destroy(objectsInMap[i, j]);
                    Destroy(objectsInMap[i - 1, j - 1]);
                    Destroy(objectsInMap[i - 2, j - 2]);
                    specialMoveCount = specialMove[0] + specialMove[1] + specialMove[2];
                    GameBoardReset(gameBoard[i, j]);
                    GameBoardReset(gameBoard[i + 1, j - 1]);
                    GameBoardReset(gameBoard[i + 2, j - 2]);
                    return true;
                }


            }
        }
        return false;
    }
    private bool CheckDraw() {
        var count = 0;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (gameBoard[i, j].player == 0)
                    count++;
            }
        }
        if (count > 0)
            return false;
        return true;
    }
    private bool IsSpecialMove() {
        return (specialMoveCount > 4);
    }
    private void GameBoardReset(Cell obj) {
        obj.player = 0;
        obj.tileSize = 0;
    }
}
