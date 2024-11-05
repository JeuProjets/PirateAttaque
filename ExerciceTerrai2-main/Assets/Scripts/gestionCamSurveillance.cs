
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCamSurveillance : MonoBehaviour
{
    public GameObject helicoptere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(helicoptere.transform);

    }
}
