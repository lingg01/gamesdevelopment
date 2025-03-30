using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int health;
    public int maxHealth = 3;

    public PlayerHealth playerHealth;

    void Update(){

        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for(int i = 0; i < hearts.Length; i++){

            if(i < health){
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth){
                hearts[i].enabled = true;
            }

            else {
                hearts[i].enabled = false;
            }
            
        }

    }
}
