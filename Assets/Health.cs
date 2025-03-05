using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;

    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update(){

        for(int i = 0; i < hearts.Length; i++){
            hearts[i].enabled = true;
        }

        else {
            hearts[i].enabled = false;
        }

    }
}
