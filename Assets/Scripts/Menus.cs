using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void SelecLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continuar()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
