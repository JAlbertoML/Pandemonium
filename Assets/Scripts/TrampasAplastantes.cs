using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasAplastantes : MonoBehaviour
{
    private GameObject trampaAplastante;
    public static bool pasoTrampas = false;
    private Vector3 vector = new Vector3();
    private static bool trampaActivada = false;
    private AudioSource audioPlataforma;
    private bool sonoPlataforma = false;

    void Start()
    {
        trampaAplastante = GameObject.FindGameObjectWithTag("TrampasAplastadoras");
        audioPlataforma = GameObject.FindGameObjectWithTag("AudioPlataforma").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trampaActivada) 
        {
            if (!sonoPlataforma)
            {
                audioPlataforma.Play();
                sonoPlataforma = true;
            }
            vector.x = trampaAplastante.transform.position.x;
            vector.y = (float)(trampaAplastante.transform.position.y - 0.011);
            vector.z = trampaAplastante.transform.position.z;
            trampaAplastante.transform.position = vector;
            if(trampaAplastante.transform.position.y <= -0.75)
            {
                trampaActivada = false;
                pasoTrampas = true;
                audioPlataforma.Stop();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        trampaActivada |= (other.gameObject.CompareTag("Player") && !pasoTrampas);
    }

    public static void ReestablecerVariables()
    {
        pasoTrampas = false;
        trampaActivada = false;
    }
}
