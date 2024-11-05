using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationDome : MonoBehaviour
{
    private AudioSource audioDome;
    public AudioClip sonDome;


    // Start is called before the first frame update
    void Start()
    {
        audioDome = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            GetComponent<Animator>().SetBool("boolOuverture", true);
            GetComponent<Animator>().SetBool("boolFermeture", false);
        }
        if (Input.GetKey(KeyCode.F))
        {
            GetComponent<Animator>().SetBool("boolFermeture", true);
            GetComponent<Animator>().SetBool("boolOuverture", false);

        }
    }


    public void joueSonDome()
    {
        audioDome.PlayOneShot(sonDome);
    }
}
