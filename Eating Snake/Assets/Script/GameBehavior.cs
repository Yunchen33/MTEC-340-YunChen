using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public Snake snake; // Reference to the Snake script
    public Transform foodPrefab; // Reference to the food prefab
    public BoxCollider2D gridArea; // Reference to the grid area where food spawns
    //private FoodSpawner foodSpawner;
    private bool isGameOver;
    public GameoverMenu gameoverMenu;
    [SerializeField] private AudioSource eatSoundEffect;

    private void Start()
    {
        //foodSpawner = new FoodSpawner();
        ResetGame();
    }


    public void ResetGame()
    {
        
        // Reset the Snake
        snake.ResetState();

        // Spawn the first food
        //foodSpawner.SpawnFood();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Debug.Log("EAT");
            snake.Grow();
            eatSoundEffect.Play();
        }
        else if (other.tag == "Obstacle" && !isGameOver)
        {
            isGameOver = true;
            gameoverMenu.gameOver();
            Debug.Log("Hit the wall, dead");
        }
    }
}
