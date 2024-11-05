using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionScenes : MonoBehaviour
{
    public Button boutonCommencer;

    // Start is called before the first frame update
    void Start()
    {
        boutonCommencer.onClick.AddListener(boutonCliquer);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void boutonCliquer()
    {
        SceneManager.LoadScene("SceneTerrain");
    }
}
