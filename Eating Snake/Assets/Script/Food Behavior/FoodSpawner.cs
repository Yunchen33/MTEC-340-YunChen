using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    
    //public Transform foodPrefab;
    //public BoxCollider2D gridArea;


    //// Default constructor
    //public FoodSpawner()
    //{
    //}

    //public FoodSpawner(BoxCollider2D gridArea, Transform foodPrefab)
    //{
    //    this.gridArea = gridArea;
    //    this.foodPrefab = foodPrefab;
    //}


    //public void SpawnFood()
    //{
    //    Bounds bounds = gridArea.bounds;
    //    float x = Random.Range(bounds.min.x, bounds.max.x);
    //    float y = Random.Range(bounds.min.y, bounds.max.y);

    //    Vector3 foodPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    //    Instantiate(foodPrefab, foodPosition, Quaternion.identity);
    //}

    public Transform foodPrefab;
    public BoxCollider2D gridArea;

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 foodPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        Instantiate(foodPrefab, foodPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpawnFood();
        }
    }
}

