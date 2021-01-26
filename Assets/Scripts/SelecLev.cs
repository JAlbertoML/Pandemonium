using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecLev : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1", LoadSceneMode.Single);
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel2", LoadSceneMode.Single);
    }

    public void Nivel3()
    {
        //SceneManager.LoadScene("Nivel3", LoadSceneMode.Single);
    }

    public void Nivel4()
    {
        //SceneManager.LoadScene("Nivel4", LoadSceneMode.Single);
    }

    public void Regresar()
    {
        SceneManager.LoadScene("EscenaStart", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
