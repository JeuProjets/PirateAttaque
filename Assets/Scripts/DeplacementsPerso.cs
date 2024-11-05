using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    public float vitesseRotationPerso; // Vitesse de rotation du personnage
    public float vitesseDeplacementPerso; // Vitesse de d�placement du personnage

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // R�cup�rer le Rigidbody attach� au personnage
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // R�cup�rer les entr�es de l'utilisateur
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        //ESSAI 1
        //// D�placement : on cr�e un vecteur directionnel � partir des entr�es (horizontal et vertical)
        //Vector3 deplacement = new Vector3(axeH, 0, axeV).normalized * vitesseDeplacementPerso;

        //// Appliquer la v�locit� uniquement sur l'axe X et Z pour le mouvement (en gardant la v�locit� en Y inchang�e)
        //rb.velocity = new Vector3(deplacement.x, rb.velocity.y, deplacement.z);

        //// Rotation : faire tourner le personnage en fonction du mouvement de la souris
        //float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        //transform.Rotate(0f, tourne, 0f);


        //ESSAI 2
        ////Selon axe du monde (par default)
        //GetComponent<Rigidbody>().velocity = new Vector3(axeH, 0, axeV).normalized * vitesseDeplacementPerso;
        ////Selon axe du personnage
        //GetComponent<Rigidbody>().velocity = transform.TransformDirection(axeH, 0, axeV).normalized * vitesseDeplacementPerso;
        ///* ### rotation du personnage simple ###
        // * on tourne le personnage en fonctione du d�placement horizontal de la souris. On mutliplie par la variable
        // * vitesseRotationPerso pour pouvoir contr�ler la vitesse de rotation*/
        //float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        //transform.Rotate(0f, tourne, 0f);

        //ESSAI 3
        // Inverser l'axe vertical (axeV) si n�cessaire (par exemple, si "W" va en arri�re au lieu d'avancer)
        axeV = -axeV;

        // D�placement : on cr�e un vecteur directionnel � partir des entr�es (horizontal et vertical)
        // Ce code applique la v�locit� de mani�re simple en fonction de l'axe mondial
        Vector3 deplacement = new Vector3(axeH, 0, axeV).normalized * vitesseDeplacementPerso;

        // Appliquer la v�locit� uniquement sur l'axe X et Z pour le mouvement (en gardant la v�locit� en Y inchang�e)
        // La gravit� va continuer � affecter le personnage gr�ce � rb.velocity.y
        rb.velocity = new Vector3(deplacement.x, rb.velocity.y, deplacement.z);

        // Rotation : faire tourner le personnage en fonction du d�placement horizontal de la souris
        float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        transform.Rotate(0f, tourne, 0f);


    }
}
