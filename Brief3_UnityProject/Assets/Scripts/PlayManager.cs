using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{

    // -- FIELDS SET IN INSPECTOR


    [SerializeField]
    private GameObject enemyPrefabRef;

    [SerializeField]
    private GameObject gameHUD; // reference to gameHUD gui game object.

    [SerializeField]
    private GameObject[] enemySpawnPositions; // four cardinal point spawn set up in the testing scene

    [SerializeField]
    private int enemiesToSpawn; // increases with waves

    [SerializeField]
    private float spawnDelay; // so you don't get swamped by spheres


    private GameObject playerPrefabRef;
    private Transform playerSpawn;
    
    // -- PRIVATE FEILDS

    private Stack<GameObject> enemySpawnPool; // instantiated enemies read to be activated (using stack cause it makes more sense than a list) Push! POP!

    public List<GameObject> activeEnemies; // "Exterminate...Exterminate..." Tank uses this to shoot the spheres hence public
        
    // -- UNTITY METHODS

    void Awake()
    {
        enemySpawnPool = new Stack<GameObject>();
    }

    private void OnEnable()
    {
        GameDirector.StartGame += PlayGame;
        OctahedronController.TankDeath += GameOver;
    }

    private void OnDisable()
    {
        GameDirector.StartGame -= PlayGame;
        OctahedronController.TankDeath += GameOver;
    }

    // -- CUSTOM METHODS

    private void GenerateSpheres() // populate the spawn pool becasue instantiation is costly at runtime.
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var enemy = Instantiate(playerPrefabRef);
            enemy.SetActive(false);
            enemySpawnPool.Push(enemy);
        }
    }

    private void SpawnSphere(GameObject sphere) // put enemy at a random spawn location then give it a liscence to kill.
    {
        var randomIndex = Random.Range(0, 3);
        sphere.transform.position = sphere.transform.position;
        sphere.SetActive(true);
        activeEnemies.Add(sphere); // splinter sphere agent activated... 
    }

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

    private void PlayGame()
    {
        Debug.Log("GameStarted");

        // switch to game UI
        gameHUD.SetActive(true);

        // spwan the player
        Instantiate(playerPrefabRef, playerSpawn);

        GenerateSpheres();

    }
    
    private void GameOver()
    {
        activeEnemies.Clear();
        enemySpawnPool.Clear();
    }

}
