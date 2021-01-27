using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbrirPuertaSecundaria : MonoBehaviour
{
    private static float x = 0;
    private static bool pWasPressed = false;
    private GameObject puertaIzq;
    private GameObject[] puertaDer;
    private GameObject textPuerta;
    Vector3 vector = new Vector3(0, 0, 0);
    private TMP_Text text;
    private AudioSource audioPuerta;
    private static bool sonoPuerta = false;
    public string label;
    public string izquierda;
    public string derecha;

    void Start()
    {

        puertaIzq = GameObject.FindGameObjectWithTag(izquierda);
        puertaDer = GameObject.FindGameObjectsWithTag(derecha);
        audioPuerta = GameObject.FindGameObjectWithTag("AudioPuerta").GetComponent<AudioSource>();
        pWasPressed = false;
        textPuerta = GameObject.FindGameObjectWithTag(label);
        text = textPuerta.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (pWasPressed)
        {
            if (!sonoPuerta)
            {
                audioPuerta.Play();
                sonoPuerta = true;
            }
            Abrir();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.color = new Color(0, 0, 0, 255);
            pWasPressed |= Input.GetKey("p");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.color = new Color(0, 0, 0, 0);
        }
    }

    private void Abrir()
    {
        if (x <= 2)
        {
            AbrirPuertaIzquierda();
            AbrirPuertaDerecha();
            MoverLabelPuerta();
            x += 0.018f;
        }
        else
        {
            ReestablecerVariables();
        }
    }

    private void AbrirPuertaIzquierda()
    {
            vector.x = puertaIzq.transform.position.x - .018f;
            vector.y = puertaIzq.transform.position.y;
            vector.z = puertaIzq.transform.position.z;
            puertaIzq.transform.position = vector;
    }

    private void AbrirPuertaDerecha()
    {
            foreach (GameObject puerta in puertaDer)
            {
                vector.x = puerta.transform.position.x + .018f;
                vector.y = puerta.transform.position.y;
                vector.z = puerta.transform.position.z;
                puerta.transform.position = vector;
            }
    }

    private void MoverLabelPuerta()
    {
            vector.x = textPuerta.transform.position.x + .018f;
            vector.y = textPuerta.transform.position.y;
            vector.z = textPuerta.transform.position.z;
            textPuerta.transform.position = vector;

    }

    public static void ReestablecerVariables()
    {
        pWasPressed = false;
        x = 0;
        sonoPuerta = false;
    }
}
