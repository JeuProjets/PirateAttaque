using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourneHelis : MonoBehaviour
{
    public Vector3 vitesseHelis;

    public float compteur;
    public bool moteurEnMarche;

    // Start is called before the first frame update
    void Start()
    {
        moteurEnMarche = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moteurEnMarche = !moteurEnMarche;
        }
        //compteur+= 1 * Time.deltaTime;
        transform.Rotate(vitesseHelis * Time.deltaTime);
    }
}

