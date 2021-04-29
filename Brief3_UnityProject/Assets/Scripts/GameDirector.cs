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
    // -- INSPECTOR SET FEILDS

    [SerializeField]
    private GameObject myGUIpanel;

    public delegate void GameStateTransition();
    public static event GameStateTransition StartGame;






    // -- PRIVATE FEILDS

    private int gameScore = 0;
   
    // -- EVENTS AND DELEGATES

    


    private void PlayGame()
    {
        Debug.Log("clicked play game button");
        StartGame?.Invoke();
    }

    private void Awake()
    {
        myGUIpanel.SetActive(true);
    }

    private void Start()
    {
            
    }



    private void Update()
    {
        
    }


}
