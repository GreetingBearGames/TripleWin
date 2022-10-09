using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public static int[] calisbe = new int[3];

    public List<GameObject> ilk9KareTemas = new List<GameObject>();
    [SerializeField] GameObject ilkObje;

    void Start()
    {
        /*
        ilkObje.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(ilkObje.transform.position, Vector2.right);
        foreach (RaycastHit2D item in hit)
        {
            Debug.Log("sağ: " + item.collider + " / " + item.collider.gameObject.name);
        }

        if (hit.Length == 1)
        {
            RaycastHit2D hit2 = Physics2D.Raycast(ilkObje.transform.position, Vector2.left);
            Debug.Log("sol: " + hit2.collider + " / " + hit2.collider.gameObject.name);
        }
        */


        //Debug.Log(hit.collider + " / " + hit.collider.gameObject.name);
        //RaycastHit2D hit2 = Physics2D.Raycast(hit.collider.gameObject.transform.position, Vector2.right, 10000);
        //Debug.Log(hit2.collider + " / " + hit2.collider.gameObject.name);

    }

    void Update()
    {

    }

    public void CheckNear(GameObject yerlestirilenItem)
    {
        ilk9KareTemas.Clear();

        //yerlestirilenItem.GetComponent<CircleCollider2D>().enabled = false;

        string hangiPlayer = yerlestirilenItem.name.Substring(0, 2);

        Vector2 itemPos = yerlestirilenItem.transform.position;
        Vector2 altKose = itemPos - new Vector2(286, 235);
        Vector2 ustKose = itemPos + new Vector2(286, 235);
        Collider2D[] tabladakiItemlar = Physics2D.OverlapAreaAll(altKose, ustKose);




        foreach (Collider2D item in tabladakiItemlar)
        {
            if (item.transform.parent.name == "Placed" && item.name.StartsWith(hangiPlayer))
            {
                ilk9KareTemas.Add(item.gameObject);

                /*ESKİ ÇALIŞAN KOD
                Debug.Log(item + "AN : " + Time.frameCount);
                item.GetComponent<CircleCollider2D>().enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(item.transform.position, yerlestirilenItem.transform.position, 50);
                if (hit.collider != null) { Debug.Log("ikinci Vurduğun: " + hit.collider.gameObject.name); }
                item.GetComponent<CircleCollider2D>().enabled = true;
                */
            }

        }
        //yerlestirilenItem.GetComponent<CircleCollider2D>().enabled = true;

        ilk9KareTemas.Remove(yerlestirilenItem);
        if (ilk9KareTemas.Count == 2)
        {
            //ilk9KareTemas[0].transform.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //ilk9KareTemas[1].transform.gameObject.GetComponent<CircleCollider2D>().enabled = false;



            RaycastHit2D[] hit = Physics2D.LinecastAll(ilk9KareTemas[0].transform.position, ilk9KareTemas[1].transform.position);
            foreach (RaycastHit2D item in hit)
            {
                Debug.Log(item.collider + " dis: " + item.distance);
            }

            /*
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.transform.gameObject);
            }*/
            /*
                        if (hit.collider.transform.gameObject.name.StartsWith(hangiPlayer))
                        {
                            Debug.Log(hit.collider.transform.gameObject);
                        }*/
        }






        //BU KISIM ÇALIŞIYOR HAA
        /*
        RaycastHit2D hit = Physics2D.Raycast(yerlestirilenItem.transform.position, Vector2.right);


        if (hit.collider.gameObject.transform.parent.name == "Placed")
        { // 4

            Debug.Log(hit.collider + " / " + hit.collider.gameObject.transform.parent.name);
            //matchingTiles.Add(hit.transform.name);
            //CheckNear(hit.collider.gameObject);
            //hit = Physics2D.Raycast(hit.collider.transform.position, Vector2.right);

        }
        */


    }











    private List<GameObject> FindMatch(Vector2 castDir)
    { // 1
        Debug.Log("aramaya başladı");
        List<GameObject> matchingTiles = new List<GameObject>(); // 2
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir); // 3
        while (hit.collider != null)
        { // 4
            Debug.Log("vurdu");
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(hit.collider.transform.position, castDir);
        }
        Debug.Log(matchingTiles);
        return matchingTiles; // 5
    }

}
