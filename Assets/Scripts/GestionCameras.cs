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
        //On commence avec le personnage au sol.
        cameraSol.SetActive(true);
        cameraTour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Lorsque la touche espace est appuy�e, la fonction qui change la camera(le personnage) est appel�e.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangerCameraPerso();
        }

    }

    void ChangerCameraPerso()
    {
        // Bascule entre les cam�ras
        bool isCameraTourActive = cameraTour.activeSelf;

        cameraTour.SetActive(!isCameraTourActive); // Active/d�sactive la cam�ra de tour
        cameraSol.SetActive(isCameraTourActive);   // Active/d�sactive la cam�ra au sol
    }
}
