using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStart : MonoBehaviour
{
    [SerializeField] GameObject HorLayoutObject;


    void Start()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(HorLayoutObject.GetComponent<RectTransform>());
    }


    void Update()
    {

    }
}
