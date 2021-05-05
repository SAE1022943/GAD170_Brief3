using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    // FIELD DECLARATIONS

    // --- SET IN INSPECTOR

    [SerializeField]
    private GameObject enemyPrefabRef; // refernece to the Sinister Sphere

    [SerializeField]
    private GameObject gameHUD; // reference to gameHUD gui game object.

    [SerializeField]
    private GameObject[] enemySpawnPositions; // four cardinal point spawn set up in the testing scene

    [SerializeField]
    private int enemiesToSpawn; // increases with waves

    [SerializeField]
    private float spawnDelay; // so you don't get swamped by spheres

    [SerializeField]
    private GameObject playerPrefabRef;
    
    private Transform playerSpawn; // the location where the player is spawned, centre of the floor
    
    // --- PRIVATE FEILDS

    private Stack<GameObject> enemySpawnPool; // instantiated enemies read to be activated (using stack cause it makes more sense than a list) Push! POP!

    public List<GameObject> activeEnemies; // "Exterminate...Exterminate..." Tank uses this to shoot the spheres hence public

    // --- Delegates and Events

    private delegate void Targets(List<GameObject> _targets);
    private static event Targets sendTargetsToTank;

    // METHODS

    // --- UNTITY METHODS

    /// <summary>
    /// instantiate private fields at runtime
    /// </summary>
    void Awake()
    {
        enemySpawnPool = new Stack<GameObject>();
    }

    /// <summary>
    /// Attaching event listeners to functions
    /// </summary>
    private void OnEnable()
    {
        GameDirector.StartGame += PlayGame; // when the user presses play initiate play.
        OctahedronController.TankDeath += GameOver; // when the player tank dies stop the game
    }

    /// <summary>
    /// Unsubscribing event listeners when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
        GameDirector.StartGame -= PlayGame;
        OctahedronController.TankDeath += GameOver;
    }

    // -- CUSTOM METHODS

    /// <summary>
    /// Initiate the game by spawning the player and the enemyspheres
    /// </summary>
    private void PlayGame()
    {
        
        Debug.Log("GameStarted");

        // switch to game UI
        gameHUD.SetActive(true);

        // spawn the player
        Instantiate(playerPrefabRef, playerSpawn);

        // Generate the enemies
        GenerateSpheres();

    }

    /// <summary>
    /// Creates spheres based upon the inspector set enemies to spawn integer value
    /// </summary>
    private void GenerateSpheres() // populate the spawn pool becasue instantiation is costly at runtime.
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var enemy = Instantiate(enemyPrefabRef);
            enemy.SetActive(false);
            enemySpawnPool.Push(enemy);
        }
    }

    /// <summary>
    /// Put the given sphere enemy at a random spawn point and then activate the object and add it to the active enemies roster list. 
    /// </summary>
    /// <param name="sphere"></param>
    private void SpawnSphere(GameObject sphere) // put enemy at a random spawn location then give it a liscence to kill.
    {
        var randomIndex = Random.Range(0, 3);
        sphere.transform.position = enemySpawnPositions[randomIndex].transform.position;
        sphere.SetActive(true);
        activeEnemies.Add(sphere); // splinter sphere agent activated...

    }

    /// <summary>
    /// Will allow spheres to spawn after the passed in spawn delay.
    /// </summary>
    /// <param name="_spawnDelay"></param>
    /// <returns></returns>
    IEnumerator SpawnSphereWindow(float _spawnDelay)
    {

        while (enabled)
        {

            if (enemySpawnPool.Count != 0)
            {
                var selection = enemySpawnPool.Pop();
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    /// <summary>
    /// When the player dies, clear the spawn pools to stop the game.
    /// </summary>
    private void GameOver()
    {
        activeEnemies.Clear();
        enemySpawnPool.Clear();
    }

}
