//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeplacementsPerso : MonoBehaviour
//{
//    public float vitesseRotationPerso; // Vitesse de rotation du personnage
//    public float vitesseDeplacementPerso; // Vitesse de d�placement du personnage

//    private Rigidbody rigidPerso;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // R�cup�rer le Rigidbody attach� au personnage
//        rigidPerso = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        // Touches de d�placement
//        float axeH = Input.GetAxisRaw("Horizontal");
//        float axeV = Input.GetAxisRaw("Vertical");

//        // Cr�er un vecteur de d�placement local
//        Vector3 deplacement = new Vector3(-axeH, 0, -axeV);

//        // Normaliser le vecteur de d�placement pour �viter les d�placements plus rapides
//        if (deplacement.magnitude > 1f)
//        {
//            deplacement.Normalize();
//        }

//        // Convertir le d�placement local en d�placement global
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
//            // le personnage regarde vers le point de contact (l� ou le rayon � touch� le plancher)
//            transform.LookAt(infoCollision.point);

//            /* Ici, on s'assure que le personnage tourne seulement sur son Axe Y en mettant ses rotations X et Z � 0. Pour changer
//             * ces valeurs par programmation, il faut changer la propri�t� localEuleurAngles.*/
//            Vector3 rotationActuelle = transform.localEulerAngles;
//            rotationActuelle.x = 0f;
//            rotationActuelle.z = 0f;
//            transform.localEulerAngles = rotationActuelle;
//        }
//        //outil de d�boggage pour visualiser le rayon dans l'onglet scene
//        Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.yellow);
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
    public float vitesseRotationPerso = 2f; // Sensibilit� de la souris
    public float vitesseDeplacementPerso = 5f; // Vitesse de d�placement du personnage

    private Rigidbody rigidPerso;
    private Camera cameraPerso; // R�f�rence � la cam�ra
    private float rotationX = 0f; // Angle vertical (axe X) pour la cam�ra

    void Start()
    {
        // R�cup�rer le Rigidbody attach� au personnage
        rigidPerso = GetComponent<Rigidbody>();

        // Trouver automatiquement la cam�ra enfant
        cameraPerso = GetComponentInChildren<Camera>();
           

        // Verrouiller le curseur dans la fen�tre
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // D�placement du personnage
        DeplacerPersonnage();

        // Gestion des rotations
        TournePersonnage();
    }

    void DeplacerPersonnage()
    {
        // Touches de d�placement
        float axeH = Input.GetAxisRaw("Horizontal");
        float axeV = Input.GetAxisRaw("Vertical");

        // Cr�er un vecteur de d�placement local
        Vector3 deplacement = new Vector3(-axeH, -2f, -axeV);
        //POUR LE SAUT Vector3 deplacement = new Vector3(-axeH, forceSaut + gravite, -axeV);

        // Normaliser pour �viter d'aller plus vite en diagonale
        if (deplacement.magnitude > 1f)
        {
            deplacement.Normalize();
        }

        // Convertir le d�placement local en d�placement global
        Vector3 deplacementGlobal = transform.TransformDirection(deplacement);

        // Appliquer la vitesse au Rigidbody
        rigidPerso.velocity = deplacementGlobal * vitesseDeplacementPerso;
    }

    void TournePersonnage()
    {
        // Rotation horizontale (axe Y) pour le personnage
        float sourisX = Input.GetAxis("Mouse X") * vitesseRotationPerso;
        transform.Rotate(0f, sourisX, 0f);

        // Rotation verticale (axe X) pour la cam�ra
        float sourisY = Input.GetAxis("Mouse Y") * vitesseRotationPerso;

        // Ajuster l'angle vertical et le limiter
        rotationX -= sourisY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limiter entre -90� et +90�

        // Appliquer la rotation verticale uniquement � la cam�ra
        cameraPerso.transform.localEulerAngles = new Vector3(rotationX, 180f, 0f);
    }
}

