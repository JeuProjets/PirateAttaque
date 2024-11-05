using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameraCoffre : MonoBehaviour
{
    public GameObject camCoffre;
    public GameObject camBateau;

    public GameObject titreDuJeu;

    public GameObject boutonCommencer;

    
    // Start is called before the first frame update
    void Start()
    {
        camCoffre.SetActive(true);
        camBateau.SetActive(false);
        titreDuJeu.SetActive(true);
    }

   

    public void DesactiverCameraCoffre()
    {
        camCoffre.SetActive(false);
        camBateau.SetActive(true);
        titreDuJeu.SetActive(false);

        Invoke("instructionsDuJeu",3f);
    } 

    public void instructionsDuJeu()
    {
        boutonCommencer.SetActive(true);
    }
}