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
    
    private bool isPlayingTheGame = false;

    private int gameScore = 0;

    // Delegate for my event
    private delegate void GameEvent();
    private static event GameEvent gameEvent;


    private void PlayGame()
    {


        if ( !isPlayingTheGame && Input.GetKeyDown("Space") )
        {
            // start the game
            gameEvent?.Invoke();
            // set game to play
            isPlayingTheGame = true;

        }




    }

      
   

    private void Awake()
    {
       




    }

    private void Start()
    {





       
    }

}
