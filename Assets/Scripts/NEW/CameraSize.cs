using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] SpriteRenderer camerasize;

    /*
    void Awake()
    {
        Debug.Log(camerasize.bounds.size.y);
        Debug.Log(Camera.main.orthographicSize);
        this.transform.position = camerasize.transform.position;
        this.GetComponent<Camera>().orthographicSize = camerasize.bounds.size.y * 0.5f;
        //float orthoSize = camerasize.bounds.size.x * Screen.height / Screen.width * 0.5f;
        //Camera.main.orthographicSize = orthoSize;
    }
    */

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().rendererPriority = 1;
    }
}
