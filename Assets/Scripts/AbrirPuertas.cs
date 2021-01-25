using UnityEngine;
using TMPro;

public class AbrirPuertas : MonoBehaviour
{
    private float x = 0;
    private bool pWasPressed = false;
    private GameObject puertaIzq;
    private GameObject[] puertaDer;
    private GameObject textPuerta;
    Vector3 vector = new Vector3(0, 0, 0);
    private TMP_Text text;

    void Start()
    { 
        textPuerta = GameObject.FindGameObjectWithTag("LabelPuerta");
        text = textPuerta.GetComponent<TMP_Text>();
        puertaIzq = GameObject.FindGameObjectWithTag("PuertaIzquierda");
        puertaDer = GameObject.FindGameObjectsWithTag("PuertaDerecha");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.color = new Color(0, 0, 0, 255);
            pWasPressed |= Input.GetKey("p");
            if (pWasPressed)
            {
                Abrir();
            }
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
        if(x <= 2)
        {
            AbrirPuertaIzquierda();
            AbrirPuertaDerecha();
            MoverLabelPuerta();
            x += 0.02f;
        }
    }

    private void AbrirPuertaIzquierda()
    {
        vector.x = puertaIzq.transform.position.x;
        vector.y = puertaIzq.transform.position.y;
        vector.z = puertaIzq.transform.position.z - .02f;
        puertaIzq.transform.position = vector;
    }

    private void AbrirPuertaDerecha()
    {
        foreach (GameObject puerta in puertaDer)
        {
            vector.x = puerta.transform.position.x;
            vector.y = puerta.transform.position.y;
            vector.z = puerta.transform.position.z + .02f;
            puerta.transform.position = vector;
        }
    }

    private void MoverLabelPuerta()
    {
        vector.x = textPuerta.transform.position.x;
        vector.y = textPuerta.transform.position.y;
        vector.z = textPuerta.transform.position.z + .02f;
        textPuerta.transform.position = vector;
    }
}
