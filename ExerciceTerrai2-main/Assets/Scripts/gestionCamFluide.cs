using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class gestionCamFluide : MonoBehaviour
{
    public GameObject helicoptere;
    //float laVitesse = 0.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 positionCamera = helicoptere.transform.TransformPoint(0, 0.05f, -0.1f);
        //laVitesse = Vector3.Lerp(transform.position, positionCamera, 0.2f);

        transform.LookAt(helicoptere.transform);
    }
}
