using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    //public float vitesseRotationPerso; // Vitesse de rotation du personnage
    public float vitesseDeplacementPerso; // Vitesse de déplacement du personnage

    private Rigidbody rigidPerso;

    // Start is called before the first frame update
    void Start()
    {
        // Récupérer le Rigidbody attaché au personnage
        rigidPerso = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Touches de déplacement
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        // Déplacer le personnage
        rigidPerso.velocity=new Vector3(axeH, 0, axeV) * vitesseDeplacementPerso;

        // Rotation du personnage avec la souris (PAS FINI)
        //float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        //transform.Rotate(0f, tourne, 0f);

    }
}
