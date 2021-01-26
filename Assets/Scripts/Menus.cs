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
        SceneManager.LoadScene("EscenaPrincipal", LoadSceneMode.Single);
    }

    public void SelecLevel()
    {
        SceneManager.LoadScene("SelectLevel", LoadSceneMode.Single);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
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
