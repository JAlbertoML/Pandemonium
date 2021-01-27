using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IluminarReactor : MonoBehaviour
{
    public GameObject verificador;
    public GameObject particleSystem;
    public GameObject pointLight;

    void Start()
    {
        particleSystem.GetComponent<ParticleSystem>().Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Verificador"))
        {
            particleSystem.GetComponent<ParticleSystem>().Play();
            pointLight.GetComponent<Light>().enabled = true;
        }
    }
}
