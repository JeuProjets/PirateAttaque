//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeplacementsPerso : MonoBehaviour
//{
//    public float vitesseRotationPerso; // Vitesse de rotation du personnage
//    public float vitesseDeplacementPerso; // Vitesse de déplacement du personnage

//    private Rigidbody rigidPerso;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Récupérer le Rigidbody attaché au personnage
//        rigidPerso = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        // Touches de déplacement
//        float axeH = Input.GetAxisRaw("Horizontal");
//        float axeV = Input.GetAxisRaw("Vertical");

//        // Créer un vecteur de déplacement local
//        Vector3 deplacement = new Vector3(-axeH, 0, -axeV);

//        // Normaliser le vecteur de déplacement pour éviter les déplacements plus rapides
//        if (deplacement.magnitude > 1f)
//        {
//            deplacement.Normalize();
//        }

//        // Convertir le déplacement local en déplacement global
//        Vector3 deplacementGlobal = transform.TransformDirection(deplacement);

//        // Appliquer la vitesse au Rigidbody
//        rigidPerso.velocity = deplacementGlobal * vitesseDeplacementPerso;

//        // Rotation du personnage avec la souris
//        float tourne = Input.GetAxis("Mouse X") * vitesseRotationPerso;
//        transform.Rotate(0f, tourne, 0f);

//        TournePersonnage();
//    }



//    void TournePersonnage()
//    {

//        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

//        RaycastHit infoCollision;

//        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 5000, LayerMask.GetMask("plancher")))
//        {
//            // si le rayon frappe le plancher...
//            // le personnage regarde vers le point de contact (là ou le rayon à touché le plancher)
//            transform.LookAt(infoCollision.point);

//            /* Ici, on s'assure que le personnage tourne seulement sur son Axe Y en mettant ses rotations X et Z à 0. Pour changer
//             * ces valeurs par programmation, il faut changer la propriété localEuleurAngles.*/
//            Vector3 rotationActuelle = transform.localEulerAngles;
//            rotationActuelle.x = 0f;
//            rotationActuelle.z = 0f;
//            transform.localEulerAngles = rotationActuelle;
//        }
//        //outil de déboggage pour visualiser le rayon dans l'onglet scene
//        Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.yellow);
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    public float vitesseRotationPerso = 2f; // Sensibilité de la souris
    public float vitesseDeplacementPerso = 5f; // Vitesse de déplacement du personnage

    private Rigidbody rigidPerso;
    private Camera cameraPerso; // Référence à la caméra
    private float rotationX = 0f; // Angle vertical (axe X) pour la caméra

    void Start()
    {
        // Récupérer le Rigidbody attaché au personnage
        rigidPerso = GetComponent<Rigidbody>();

        // Trouver automatiquement la caméra enfant
        cameraPerso = GetComponentInChildren<Camera>();
           

        // Verrouiller le curseur dans la fenêtre
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // Déplacement du personnage
        DeplacerPersonnage();

        // Gestion des rotations
        TournePersonnage();
    }

    void DeplacerPersonnage()
    {
        // Touches de déplacement
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        // Créer un vecteur de déplacement local
        Vector3 deplacement = new Vector3(-axeH, -2f, -axeV);
        //POUR LE SAUT Vector3 deplacement = new Vector3(-axeH, forceSaut + gravite, -axeV);

        // Normaliser pour éviter d'aller plus vite en diagonale
        if (deplacement.magnitude > 1f)
        {
            deplacement.Normalize();
        }

        // Convertir le déplacement local en déplacement global
        Vector3 deplacementGlobal = transform.TransformDirection(deplacement);

        // Appliquer la vitesse au Rigidbody
        rigidPerso.velocity = deplacementGlobal * vitesseDeplacementPerso;
    }

    void TournePersonnage()
    {
        // Rotation horizontale (axe Y) pour le personnage
        float sourisX = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        transform.Rotate(0f, sourisX, 0f);

        // Rotation verticale (axe X) pour la caméra
        float sourisY = Input.GetAxis("Mouse Y") * vitesseRotationPerso;

        // Ajuster l'angle vertical et le limiter
        rotationX -= sourisY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limiter entre -90° et +90°

        // Appliquer la rotation verticale uniquement à la caméra
        cameraPerso.transform.localEulerAngles = new Vector3(rotationX, 180f, 0f);
    }
}

