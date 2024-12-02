using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
public float vitesseRotationPerso; // Sensibilité de la souris
public float vitesseDeplacementPerso; // Vitesse de déplacement du personnage
public float forceDuSaut;

private Rigidbody rigidPerso;
private Camera cameraPerso; // Référence à la caméra
private float rotationX; // Angle vertical (axe X) pour la caméra

private bool enSaut; // Vérifie si le personnage est au sol

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

void Update()
{
    // Déplacement horizontal et vertical
    float axeH = Input.GetAxisRaw("Horizontal");
    float axeV = Input.GetAxisRaw("Vertical");

    Vector3 velociteLocale = transform.TransformDirection(axeH, 0f, axeV).normalized * vitesseDeplacementPerso;
    Vector3 velociteActuelle = rigidPerso.velocity;
    velociteLocale.y = velociteActuelle.y; 

    rigidPerso.velocity = velociteLocale;

    // Gestion des rotations
    TournePersonnage();

    // Saut
    if (Input.GetKeyDown(KeyCode.Space) && !enSaut)
    {
        rigidPerso.AddForce(Vector3.up * forceDuSaut, ForceMode.Impulse);
        enSaut = true;
    }

}

private void OnCollisionEnter(Collision collision)
{
   enSaut = false;
}

private void OnCollisionExit(Collision collision)
{
    // Détecte si le personnage quitte le sol
    if (collision.gameObject.CompareTag("Sol"))
    {
        enSaut = false;
    }
}

private void TournePersonnage()
{
    float rotationY = Input.GetAxis("Mouse X") * vitesseRotationPerso;
    transform.Rotate(0f, rotationY, 0f);

    rotationX -= Input.GetAxis("Mouse Y") * vitesseRotationPerso;
    rotationX = Mathf.Clamp(rotationX, -90f, 90f);
    cameraPerso.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
}
}


