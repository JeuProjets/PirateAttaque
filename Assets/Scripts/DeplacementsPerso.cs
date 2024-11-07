using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    //public float vitesseRotationPerso; // Vitesse de rotation du personnage
    public float vitesseDeplacementPerso; // Vitesse de d�placement du personnage

    private Rigidbody rigidPerso;

    // Start is called before the first frame update
    void Start()
    {
        // R�cup�rer le Rigidbody attach� au personnage
        rigidPerso = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Touches de d�placement
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        // D�placer le personnage
        rigidPerso.velocity=new Vector3(axeH, 0, axeV) * vitesseDeplacementPerso;

        // Rotation du personnage avec la souris (PAS FINI)
        //float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        //transform.Rotate(0f, tourne, 0f);

    }
}
