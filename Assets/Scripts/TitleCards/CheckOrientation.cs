using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrientation : MonoBehaviour
{
    public GameObject canvasLandscape, canvasPortrait;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.width < Screen.height)
        {
            canvasPortrait.SetActive(true);
        }
        else
        {
            canvasLandscape.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
