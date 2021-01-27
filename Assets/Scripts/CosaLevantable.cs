using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosaLevantable : MonoBehaviour
{
    public bool esAgarrable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AreaDeLevantar"))
        {
            other.GetComponentInParent<LevantarCosas>().cosa = this.gameObject;
            CambiarInstruccion.MostrarMensaje("AgarrarObjeto");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AreaDeLevantar"))
        {
            other.GetComponentInParent<LevantarCosas>().cosa = null;
            CambiarInstruccion.QuitarMensaje();
        }
    }
}
