using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourneObjet : MonoBehaviour
{
    public Vector3 vitesseRotation;
    public float vitesseRotationMax;

    public bool moteurEnMarche;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moteurEnMarche = !moteurEnMarche;
        }

        if (moteurEnMarche)
        {
            if (vitesseRotation.y < vitesseRotationMax)
            {
                vitesseRotation.y += acceleration;
            }
            else
            {
                if (vitesseRotation.y > 0)
                {
                    vitesseRotation.y = Mathf.Clamp(vitesseRotation.y -= acceleration, 0f, vitesseRotationMax);
                }
            }

            transform.Rotate(vitesseRotation * Time.deltaTime);
        }
    }
}
