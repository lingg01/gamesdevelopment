using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Time.timeScale = 1;
        }
    }
}
