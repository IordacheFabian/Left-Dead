using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MapSelector : MonoBehaviour
{
    private string cargo = "Cargo";
    private string werehouse = "Warehouse";
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void SelectCargo()
    {
        SceneManager.LoadScene(cargo);
    }

    public void SelectWarehouse()
    {
        SceneManager.LoadScene(werehouse);
    }
}
