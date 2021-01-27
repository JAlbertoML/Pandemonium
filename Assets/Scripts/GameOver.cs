using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject personaje;
    public string motivo;
    private static Canvas canvas;
    private new AudioSource audio;
    private static ThirdPersonOrbitCamBasic cam;
    private AudioSource audioPlataforma;
    private AudioSource grito;
    private AudioSource gameOverAudio;
    private bool sonoGrito = false;
    private bool sonoGOS = false;

    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonOrbitCamBasic>();
        audio = GameObject.FindGameObjectWithTag("Musica").GetComponent<AudioSource>();
        audioPlataforma = GameObject.FindGameObjectWithTag("AudioPlataforma").GetComponent<AudioSource>();
        grito = GameObject.FindGameObjectWithTag("Grito").GetComponent<AudioSource>();
        gameOverAudio = GameObject.FindGameObjectWithTag("GameOverAudio").GetComponent<AudioSource>();
        cam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(motivo == "Aplastado")
        {
            if(personaje.transform.position.y <= -0.33)
            {
                if (!sonoGrito)
                {
                    grito.Play();
                    sonoGrito = true;
                }

                canvas.enabled = true;
                cam.enabled = false;
                audio.Stop();
                audioPlataforma.Stop();
                if (!sonoGOS)
                {
                    gameOverAudio.Play();
                    sonoGOS = true;
                }

            }
        }
    }

    public void Reintentar()
    {
        ReestablecerVariables();
        Pause.ReestablecerVariables();
        TrampasAplastantes.ReestablecerVariables();
        CambiarInstruccion.ReestablecerVariables();
        AbrirPuertas.ReestablecerVariables();
        cam.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void GoToMenu()
    {
        ReestablecerVariables();
        Pause.ReestablecerVariables();
        TrampasAplastantes.ReestablecerVariables();
        CambiarInstruccion.ReestablecerVariables();
        AbrirPuertas.ReestablecerVariables();
        AbrirPuertaSecundaria.ReestablecerVariables();
        SceneManager.LoadScene("EscenaStart", LoadSceneMode.Single);
    }

    public static void ReestablecerVariables()
    {
        canvas.enabled = false;
        cam.enabled = true;
    }
}
