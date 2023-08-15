using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    [SerializeField]

    private void Start()
    {
        RandomizePosition();
        //Generator()
    }

        private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    //private void Generator()
    //{

    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player");
        {
            RandomizePosition();
        }
    }


}
