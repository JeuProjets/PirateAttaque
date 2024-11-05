using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class gestionCamFixe : MonoBehaviour
{
    public GameObject helicoptere;
    public Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (helicoptere.transform.position + distance);
        transform.LookAt(helicoptere.transform);
    }
}
