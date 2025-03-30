using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BranchManager : MonoBehaviour
{
    public int branchCount;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + branchCount.ToString();

        if(branchCount == 6)
        {
            SceneManager.LoadScene("GameOver");
            Time.timeScale = 1;
        }

    }
}
