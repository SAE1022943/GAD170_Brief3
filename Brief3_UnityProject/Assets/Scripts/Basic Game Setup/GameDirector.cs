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

    public GameObject mainMenu;
    public GameObject gameOverScreen;

    public delegate void GameStateTransition();
    public static event GameStateTransition StartGame;

    // -- PRIVATE FEILDS

    private int finalGameScore = 0;
  
    // -- UNITY METHODS
    
    private void Awake()
    {
        mainMenu.SetActive(true);
    }

    private void OnEnable()
    {
        OctahedronController.TankDeath += GameOver;
    }

    private void OnDisable()
    {
        OctahedronController.TankDeath += GameOver;
    }

    // -- CUSTOM METHODS

    private void PlayGame()
    {
        Debug.Log("clicked play game button");
        StartGame?.Invoke();
    }

    private void GameOver()
    {
        Debug.Log("GameOver, mwahahaha");
        gameOverScreen.SetActive(true);
    }



}
