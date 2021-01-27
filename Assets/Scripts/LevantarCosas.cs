using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarCosas : MonoBehaviour
{
    public GameObject cosa;
    public GameObject cosaAgarrada;
    public Transform AreaDeLevantar;
    public GameObject camera;
     
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cosa != null && cosa.GetComponent<CosaLevantable>().esAgarrable == true && cosaAgarrada == null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                camera.GetComponent<ThirdPersonOrbitCamBasic>().verticalAimingSpeed = 6;
                cosaAgarrada = cosa;
                cosaAgarrada.GetComponent<CosaLevantable>().esAgarrable = false;
                cosaAgarrada.transform.SetParent(AreaDeLevantar);
                cosaAgarrada.transform.position = AreaDeLevantar.position;
                cosaAgarrada.GetComponent<Rigidbody>().useGravity = false;
                cosaAgarrada.GetComponent<Rigidbody>().isKinematic = true;
                CambiarInstruccion.QuitarMensaje();
            }
        }
        else if(cosaAgarrada != null)
        {
            if (Input.GetMouseButtonUp(1))
            {
                camera.GetComponent<ThirdPersonOrbitCamBasic>().verticalAimingSpeed = 0;
                cosaAgarrada.GetComponent<CosaLevantable>().esAgarrable = true;
                cosaAgarrada.transform.SetParent(null);
                cosaAgarrada.GetComponent<Rigidbody>().useGravity = true;
                cosaAgarrada.GetComponent<Rigidbody>().isKinematic = false;
                cosaAgarrada = null;
            }
        }
    }
}
