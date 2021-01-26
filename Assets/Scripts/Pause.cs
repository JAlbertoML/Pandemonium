﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private Canvas canvas;
    private bool isPaused = false;
    private new AudioSource audio;
    private ThirdPersonOrbitCamBasic cam;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonOrbitCamBasic>();
        audio = GameObject.FindGameObjectWithTag("Musica").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            canvas.enabled = isPaused;
            Time.timeScale = (isPaused) ? 0 : 1f;
            cam.enabled = !isPaused;
            if (isPaused)
            {
                audio.Pause();
            }
            else
            {
                audio.Play();
            }
        }
    }

    public void QuitPauseWithButton()
    {
        isPaused = false;
        canvas.enabled = false;
        Time.timeScale = 1f;
        cam.enabled = true;
        audio.Play();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("EscenaStart", LoadSceneMode.Single);
    }
}