using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    private Color originalTrapColor;
    private Color originalGoalColor;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode; 
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }
    public void PlayMaze(int sceneID)
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = originalGoalColor;
            goalMat.color = originalTrapColor;
        }
        SceneManager.LoadScene(sceneID);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (trapMat != null) originalTrapColor = trapMat.color;
        if (goalMat != null) originalGoalColor = goalMat.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
