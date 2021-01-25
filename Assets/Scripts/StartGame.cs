using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) { 
        if(other.collider.tag == "Puerta"){
            SceneManager.LoadScene("Nivel1");
        }
    }
}
