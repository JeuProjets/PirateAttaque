using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameraCoffre : MonoBehaviour
{
    // Cam�ra qui montre le coffre
    public GameObject camCoffre;
    // Cam�ra qui montre le bateau
    public GameObject camBateau;

    public GameObject titreDuJeu;
    public GameObject boutonCommencer;

    // D�but : on active la cam�ra du coffre et affiche le titre
    void Start()
    {
        camCoffre.SetActive(true);
        camBateau.SetActive(false);
        titreDuJeu.SetActive(true);
    }

    // D�sactiver la cam�ra du coffre et activer celle du bateau
    public void DesactiverCameraCoffre()
    {
        camCoffre.SetActive(false);
        camBateau.SetActive(true);
        titreDuJeu.SetActive(false);

        // Affiche le bouton commencer apr�s 3 secondes
        Invoke("instructionsDuJeu", 3f);
    }

    // Activer le bouton pour commencer le jeu
    public void instructionsDuJeu()
    {
        boutonCommencer.SetActive(true);
    }
}