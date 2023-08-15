using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    bool dead = false;
    bool gamePause = false;

    public GameOverMenu GameOverMenu;
    int score = 0;


    private void Update()
    {
        if (transform.position.y < -6f && !dead)
        {
            Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerBehavior>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        gamePause = true;
        //Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play();
        Gameover();

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Gameover()
    {
        GameOverMenu.Setup(score);
    }

}
