using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        StartCoroutine(SahneYukleme(1));
    }

    public void Restart()
    {
        StartCoroutine(SahneYukleme(1));
    }


    public void TurntoMainMenu()
    {
        StartCoroutine(SahneYukleme(0));
    }

    IEnumerator SahneYukleme(int sahnenumarasi)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sahnenumarasi);
    }
}
