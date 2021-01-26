using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambiarInstruccion : MonoBehaviour
{
    private const string BORRAR = "Borrar";
    private const string SALTAR = "Saltar";
    private readonly Dictionary<string, string> msgDictionary = new Dictionary<string, string>
    {
        {"Acercarse", "Acercate a la puerta."},
        {"Correr", "Presiona shift izquierdo mientras te mueves para correr."}
    };
    private TMP_Text textoMensaje;
    public string msg;
    private Canvas canvasMsg;
    private bool salto = false;
    private bool corrio = false;

    void Start()
    {
        textoMensaje = GameObject.FindGameObjectWithTag("Mensaje").GetComponent<TMP_Text>();
        canvasMsg = GameObject.FindGameObjectWithTag("CanvasMsg").GetComponent<Canvas>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (!corrio || !salto))
        {
            if(msg == BORRAR)
            {
                QuitarMensaje();
            }
            else if(msgDictionary.ContainsKey(msg))
            {
                MostrarMensaje();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !salto)
        {
            QuitarMensaje();
            salto = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && !corrio)
        {
            QuitarMensaje();
            corrio = true;
        }
    }

    private void QuitarMensaje()
    {
        canvasMsg.enabled = false;
    }

    private void MostrarMensaje()
    {
        textoMensaje.text = msgDictionary[msg];
        canvasMsg.enabled = true;
    }
}
