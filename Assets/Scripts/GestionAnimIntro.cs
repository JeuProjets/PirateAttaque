using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameraCoffre : MonoBehaviour
{
    // Caméra qui montre le coffre
    public GameObject camCoffre;
    // Caméra qui montre le bateau
    public GameObject camBateau;

    public GameObject titreDuJeu;
    public GameObject boutonCommencer;

    // Début : on active la caméra du coffre et affiche le titre
    void Start()
    {
        camCoffre.SetActive(true);
        camBateau.SetActive(false);
        titreDuJeu.SetActive(true);
    }

    // Désactiver la caméra du coffre et activer celle du bateau
    public void DesactiverCameraCoffre()
    {
        camCoffre.SetActive(false);
        camBateau.SetActive(true);
        titreDuJeu.SetActive(false);

        // Affiche le bouton commencer après 3 secondes
        Invoke("instructionsDuJeu", 3f);
    }

    // Activer le bouton pour commencer le jeu
    public void instructionsDuJeu()
    {
        boutonCommencer.SetActive(true);
    }
}