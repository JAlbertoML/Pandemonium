using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambiarInstruccion : MonoBehaviour
{
    private const string BORRAR = "Borrar";
    private const string SALTAR = "Saltar";
    private static readonly Dictionary<string, string> msgDictionary = new Dictionary<string, string>
    {
        {"Acercarse", "Acercate a la puerta."},
        {"Correr", "Presiona shift izquierdo mientras te mueves para correr."},
        {"Pause", "Puedes presionar la tecla ESC para pausar el juego."},
        {"PrimeraPrueba", "Felicidades! Has sobrevivido al primer intento de asesinarte."},
        {"AgarrarObjeto", "Manten presionado el clic derecho para agarrar y transportar el objeto."},
        {"SiguientePuerta", "Busca la siguiente puerta."},
        {"NoAbre", "Para abrir esta puerta, debes buscar el reactor y ponerlo en su lugar."},
        {"TutoFin", "Felicidades!!! Has completado el tutorial."}
    };
    private static TMP_Text textoMensaje;
    public string msg;
    private static Canvas canvasMsg;
    private static bool salto = false;
    private static bool corrio = false;
    private static bool pauso = false;
    private static bool primeraPrueba = false;

    void Start()
    {
        textoMensaje = GameObject.FindGameObjectWithTag("Mensaje").GetComponent<TMP_Text>();
        canvasMsg = GameObject.FindGameObjectWithTag("CanvasMsg").GetComponent<Canvas>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (!corrio || !salto || !primeraPrueba))
        {
            if(msg == BORRAR)
            {
                QuitarMensaje();
            }
            else if(msgDictionary.ContainsKey(msg))
            {
                MostrarMensaje(msg);
                if(msg == "PrimeraPrueba")
                {
                    primeraPrueba = true;
                }
            }
        }

        else if (other.gameObject.CompareTag("Reactor"))
        {
            MostrarMensaje("TutoFin");
            msgDictionary["NoAbre"] = "Ahora puedes ir al siguiente nivel.";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !salto)
        {
            QuitarMensaje();
            salto = true;
            MostrarMensaje("Pause");
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !corrio)
        {
            QuitarMensaje();
            corrio = true;
            MostrarMensaje("PrimeraPrueba");
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !pauso)
        {
            QuitarMensaje();
            pauso = true;
        }
    }

    public static void QuitarMensaje()
    {
        canvasMsg.enabled = false;
    }

    public static void MostrarMensaje(string m)
    {
        textoMensaje.text = msgDictionary[m];
        canvasMsg.enabled = true;
    }

    public static void ReestablecerVariables()
    {
        salto = false;
        corrio = false;
        pauso = false;
        primeraPrueba = false;
    }
}
