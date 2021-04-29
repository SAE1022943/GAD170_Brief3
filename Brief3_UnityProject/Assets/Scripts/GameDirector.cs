using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 
/// This is the enterance into the program. Handles playing the game and displaying GameOver
/// Sends messages to the PlayManager
///  
/// 
/// 
/// </summary>

public class GameDirector : MonoBehaviour
{

    // INSPECTOR SET FEILDS

    private GameObject myMainMenuGUI;

    // PRIVATE FEILDS

    private bool isPlayingTheGame = false;
    private int gameScore = 0;

    // Component references
    
       
    // -- Events and Delegates
    public delegate void GameStateTransition();
    public static event GameStateTransition StartGame;


    public void Awake()
    {
      

    }




    private void PlayGame()
    {
        myGUI.SetActive(false);
    }

}
