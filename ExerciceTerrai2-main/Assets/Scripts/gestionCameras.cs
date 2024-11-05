using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gestionCameras : MonoBehaviour
{
    public GameObject CameraFPS;
    public GameObject CameraFixe;
    public GameObject CameraFluide;
    public GameObject CameraSurveillance;

    // Start is called before the first frame update
    void Start()
    {
        ActiverCamera(CameraFluide);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiverCamera(CameraFPS);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiverCamera(CameraFluide);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCamera(CameraFixe);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiverCamera(CameraSurveillance);

        }
        

    }
    public void ActiverCamera(GameObject CameraChoisie)
    {
        CameraFPS.SetActive(false);
        CameraFixe.SetActive(false);
        CameraFluide.SetActive(false);
        CameraSurveillance.SetActive(false);

        // Activer la caméra choisie
        CameraChoisie.SetActive(true);
    }

}
