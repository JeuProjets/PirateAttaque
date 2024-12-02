using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsPerso : MonoBehaviour
{
public float vitesseRotationPerso; // Sensibilit� de la souris
public float vitesseDeplacementPerso; // Vitesse de d�placement du personnage
public float forceDuSaut;

private Rigidbody rigidPerso;
private Camera cameraPerso; // R�f�rence � la cam�ra
private float rotationX; // Angle vertical (axe X) pour la cam�ra

private bool enSaut; // V�rifie si le personnage est au sol

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

void Update()
{
    // D�placement horizontal et vertical
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
    // D�tecte si le personnage quitte le sol
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


