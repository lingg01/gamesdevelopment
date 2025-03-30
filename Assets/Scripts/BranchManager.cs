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

    public GameObject branchPrefab;

    //min and max area for spawn
    public float spawnMinX = -10f;
    public float spawnMaxX = 10f;
    public float spawnMinY = -5f;
    public float spawnMaxY = 5f;

    public float spawnInterval = 2f;

    // public GameObject player;
    // public List<GameObject> collectibles;

    // private List<Vector2> activeEnemyPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemies in intervals
        InvokeRepeating("SpawnBranch", 0f, spawnInterval);
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

    void SpawnBranch()
    {

                //random position in defined area 100 units apart
                float randomX = Random.Range(spawnMinX, spawnMaxX);
                float randomY = Random.Range(spawnMinY, spawnMaxY);

                //snap to nearest 100
                randomX = Mathf.Round(randomX / 100f) * 100f;
                randomY = Mathf.Round(randomY / 100f) * 100f;

                //add 50 to every 100 units 
                randomX += 50f;
                randomY += 50f;

                Vector2 spawnPosition = new Vector2(randomX, randomY);


                GameObject branchClone = Instantiate(branchPrefab, spawnPosition, Quaternion.identity);

                branchClone.tag = "Branch";

    }
}
