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



    public GUI gameUI; // this the game UI stuff




    
    private int Score;   
    
    public delegate void Transition();
    public static event Transition startGame;



    private void Awake()
    {
       




    }



    private void Start()
    {

       
    }

}
