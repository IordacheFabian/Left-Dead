using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public TextMeshProUGUI pauseTextUI;
    public TextMeshProUGUI pressTextUI;
    public Image pauseImageUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        
        pauseImageUI.gameObject.SetActive(true);
        pressTextUI.gameObject.SetActive(true);
        pauseTextUI.gameObject.SetActive(true);

        SoundManager.Instance.ZombieChannel.volume = 0;
        SoundManager.Instance.ZombieChannel2.volume = 0;

    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        
        pauseImageUI.gameObject.SetActive(false);
        pressTextUI.gameObject.SetActive(false);
        pauseTextUI.gameObject.SetActive(false);

        SoundManager.Instance.ZombieChannel.volume = .3f;
        SoundManager.Instance.ZombieChannel2.volume = .3f;
    }
}
