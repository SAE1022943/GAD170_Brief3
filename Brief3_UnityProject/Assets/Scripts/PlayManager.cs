using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{


    private void OnEnable()
    {
        GameDirector.StartGame += PlayGame;
    }

    private void OnDisable()
    {
        GameDirector.StartGame -= PlayGame;
    }

    private void PlayGame()
    {

        Debug.Log("Game is Starting!!!");
              
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
