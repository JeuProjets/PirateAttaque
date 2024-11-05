using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    public float vitesseRotationPerso; // Vitesse de rotation du personnage
    public float vitesseDeplacementPerso; // Vitesse de déplacement du personnage

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Récupérer le Rigidbody attaché au personnage
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Récupérer les entrées de l'utilisateur
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        //ESSAI 1
        //// Déplacement : on crée un vecteur directionnel à partir des entrées (horizontal et vertical)
        //Vector3 deplacement = new Vector3(axeH, 0, axeV).normalized * vitesseDeplacementPerso;

        //// Appliquer la vélocité uniquement sur l'axe X et Z pour le mouvement (en gardant la vélocité en Y inchangée)
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
        // * on tourne le personnage en fonctione du déplacement horizontal de la souris. On mutliplie par la variable
        // * vitesseRotationPerso pour pouvoir contrôler la vitesse de rotation*/
        //float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        //transform.Rotate(0f, tourne, 0f);

        //ESSAI 3
        // Inverser l'axe vertical (axeV) si nécessaire (par exemple, si "W" va en arrière au lieu d'avancer)
        axeV = -axeV;

        // Déplacement : on crée un vecteur directionnel à partir des entrées (horizontal et vertical)
        // Ce code applique la vélocité de manière simple en fonction de l'axe mondial
        Vector3 deplacement = new Vector3(axeH, 0, axeV).normalized * vitesseDeplacementPerso;

        // Appliquer la vélocité uniquement sur l'axe X et Z pour le mouvement (en gardant la vélocité en Y inchangée)
        // La gravité va continuer à affecter le personnage grâce à rb.velocity.y
        rb.velocity = new Vector3(deplacement.x, rb.velocity.y, deplacement.z);

        // Rotation : faire tourner le personnage en fonction du déplacement horizontal de la souris
        float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        transform.Rotate(0f, tourne, 0f);


    }
}
