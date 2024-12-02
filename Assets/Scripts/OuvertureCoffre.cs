using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOuvertureCoffre : MonoBehaviour
{
    public Animator coffreAnimator; // R�f�rence � l'Animator du coffre

    private void OnTriggerEnter(Collider collision)
    {
        // V�rifie si l'objet entrant est le joueur
        if (collision.CompareTag("Player"))
        {
            // Active l'animation
            if (coffreAnimator != null)
            {
                coffreAnimator.SetTrigger("Ouvrir"); 
            }
            else
            {
                Debug.LogWarning("L'Animator du coffre n'est pas assign� !");
            }
        }
    }

}
