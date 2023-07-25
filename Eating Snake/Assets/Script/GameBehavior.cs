using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public Snake snake; // Reference to the Snake script
    public Transform foodPrefab; // Reference to the food prefab
    public BoxCollider2D gridArea; // Reference to the grid area where food spawns
    private bool isGameOver = false;
    public GameoverMenu gameoverMenu;
    public BGMusic bgMusicManager;
    public static GameBehavior Instance { get; private set; }
   

    private void Start()
    {
        ResetGame();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance of GameBehavior exists.
        }
    }

    public void ResetGame()
    {
        snake.ResetState();
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameoverMenu.gameOver();
        if (bgMusicManager != null)
        {
            bgMusicManager.GetComponent<AudioSource>().Stop();
        }
    }

    public void SpawnFood()
    {
        //// Calculate the random position within the grid area
        //float x = Random.Range(gridArea.bounds.min.x, gridArea.bounds.max.x);
        //float y = Random.Range(gridArea.bounds.min.y, gridArea.bounds.max.y);
        //Vector3 randomPosition = new Vector3(x, y, 0f);

        //// Instantiate the food prefab at the random position
        //Instantiate(foodPrefab, randomPosition, Quaternion.identity);

    }

}
