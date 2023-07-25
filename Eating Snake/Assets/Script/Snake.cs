using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize;
    private GameBehavior gameBehavior;

    [SerializeField] private AudioSource eatSoundEffect;
    [SerializeField] private AudioSource desthSoundEffect;


    private void Start()
    {
        ResetState(); //when player press start this script will call reset first
        Vector3 initialPosition = new Vector3(-26, -11, 0);
        this.transform.position = initialPosition;

        gameBehavior = FindObjectOfType<GameBehavior>();
        if (gameBehavior == null)
        {
            Debug.LogError("GameBehavior script not found in the scene.");
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _direction = Vector2.up;

        else if (Input.GetKeyDown(KeyCode.DownArrow))
            _direction = Vector2.down;

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            _direction = Vector2.left;

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            _direction = Vector2.right;

    }

    private void FixedUpdate() //body movement 跑身體，先跑這個再去Update
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }


        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y, // 移動向量,決定方向
            0.0f
        ); //snake's head
           // R(1,0) L(-1,0) U(0,1) D()
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab); //吃下去得當下
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment); //身體跑出來
    }

    public void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform); // snake's head

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab)); //snake's body
        }

        this.transform.position = Vector3.zero;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Debug.Log("Eat");
            Grow();
            eatSoundEffect.Play();
            ScoreManager.instance.AddPoint();
        }
        else if (other.tag == "Obstacle")
        {
            Debug.Log("Hit the wall");
            gameBehavior.GameOver();
            desthSoundEffect.Play();
        }
        else if (other.tag == "Body")
        {
            Debug.Log("Hit myself");
            gameBehavior.GameOver();
            desthSoundEffect.Play();
        }

    }
}
