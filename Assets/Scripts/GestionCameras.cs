using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameras : MonoBehaviour
{
    public GameObject cameraTour;
    public GameObject cameraSol;
    // Start is called before the first frame update
    void Start()
    {
        cameraSol.SetActive(true);
        cameraTour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangerCameraPerso();
        }

    }

    void ChangerCameraPerso()
    {
        // Bascule entre les caméras
        bool isCameraTourActive = cameraTour.activeSelf;

        cameraTour.SetActive(!isCameraTourActive); // Active/désactive la caméra de tour
        cameraSol.SetActive(isCameraTourActive);   // Active/désactive la caméra au sol
    }
}
