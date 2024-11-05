using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class deplacementHelico : MonoBehaviour
{
    public float vitesseAvant = 0.00f;
    public float vitesseAvantMax = 10000f;
    public float vitesseTourne = 1000f;
    public float vitesseMonte = 1000f;
    public float forceAcceleration;





    public GameObject refHeliceAvant;
    public GameObject refHeliceArriere;
    public GameObject refExplosion;
    public GameObject lumiereExplosion;
    public GameObject cameraDistanceFixe;
    public GameObject gestionnaireCameras;
    private Rigidbody rigidHelico;

    public bool finJeu;

    public AudioClip sonBidon;
    public AudioSource sonHelico;

    public float quantiteEssence;
    public Image barreBlanche;

    // Start is called before the first frame update
    void Start()
    {
        rigidHelico = GetComponent<Rigidbody>();
        sonHelico = GetComponent<AudioSource>();

    }


    void FixedUpdate()
    {
        if (finJeu == false)
        {
            if (refHeliceAvant.GetComponent<tourneObjet>().moteurEnMarche == true)
            {
                GestionEssence();

            
                if (refHeliceAvant.GetComponent<tourneObjet>().vitesseRotation.y > 34)
                {
                    //if (sonHelico.isPlaying == false)
                    //{
                    //sonHelico.Play();
                    // sonHelico.volume = refHeliceAvant.GetComponent<tourneObjet>().vitesseRotation;


                    //}
                    rigidHelico.useGravity = false;

                    float forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
                    rigidHelico.AddRelativeTorque(0, forceRotation, 0);

                    if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax)
                    {
                        vitesseAvant += 100;
                    }
                    if (Input.GetKey(KeyCode.Q) && vitesseAvant >= 100)
                    {
                        vitesseAvant -= 100;
                    }


                    float forceMonte = Input.GetAxis("Vertical") * vitesseMonte;
                    GetComponent<Rigidbody>().AddRelativeForce(0f, forceMonte, vitesseAvant);

                    transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

                }
                else
                {
                    rigidHelico.useGravity = true;
                }
            }
            else
            {
                rigidHelico.useGravity = true;
            }
        }


    }

    private void GestionEssence()
    {
        quantiteEssence -= (1 * Time.deltaTime)/120;
        barreBlanche.fillAmount = quantiteEssence;
        if(barreBlanche.fillAmount <= 0)
        {
            ExploserHelico();
        }
    }

    private void OnCollisionEnter(Collision collisionHelico)
    {

        if (collisionHelico.gameObject.name == "Terrain")
        {
            ExploserHelico();
            print("collision");
            finJeu = true;
            
            cameraDistanceFixe.SetActive(true);

            gestionnaireCameras.GetComponent<gestionCameras>().ActiverCamera(cameraDistanceFixe);
            Invoke("relancerScene", 8f);

        }

        if (collisionHelico.gameObject.tag == "drone" || collisionHelico.gameObject.name == "Dome")
        {
            ExploserHelico();
            finJeu = true;
            print("hello");
        }



    }

    public void ExploserHelico()
    {
        refExplosion.SetActive(true);
        lumiereExplosion.SetActive(true);

        rigidHelico.useGravity = true;
        rigidHelico.angularDrag = 1;
        rigidHelico.drag = 1 / 2;

        refHeliceAvant.GetComponent<tourneObjet>().moteurEnMarche = false;
        refHeliceArriere.GetComponent<tourneObjet>().moteurEnMarche = false;

    }

    void OnTriggerEnter(Collider infoCollision)
    {
        if (infoCollision.gameObject.tag == "bidon")

        {
            infoCollision.gameObject.SetActive(false);
            sonHelico.PlayOneShot(sonBidon);

        }

    }

    public void relancerScene()
    {
        SceneManager.LoadScene("deplacementHelico");
    }
}