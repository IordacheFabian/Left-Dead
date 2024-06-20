using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreUI;
    
    private string newGameScene = "SampleScene";
    private string mapV1 = "Map_v1";
    private string mapSelector = "MapScene";

    public AudioClip bg_music;
    public AudioSource main_channel;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        
        main_channel.PlayOneShot(bg_music);
        
        // Set the high score
        int highScore = SaveLoadManager.Instance.LoadHighScore();
        highScoreUI.text = $"Top Wave Survived: {highScore}";
    }

    public void StartNewGame()
    {
        main_channel.Stop();
        
        SceneManager.LoadScene(mapSelector);
    }

    public void ExitGame()
    {
        Application.Quit();
        
        
// #if UNITY_Editor
//     UnityEditor.EditorApplication.isPlaying = false;
// #else
//     Application.Quit();
// #endif
    }

    public void SelectMap()
    {
        string name = Button.ussClassName;
        print(name);
    }
}
