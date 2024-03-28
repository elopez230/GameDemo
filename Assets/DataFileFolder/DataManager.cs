using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private SaveDataFile saveDataFile; 
    public static DataManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DataManager in the scene."); 

        }
        instance = this;
    }
    public void NewGame()
    {
        this.saveDataFile = new SaveDataFile(); 
    }











}
