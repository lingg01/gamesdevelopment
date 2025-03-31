using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSpawner : MonoBehaviour
{

    public GameObject[] flowerPrefabs;
    public float spawnInterval = 1f;
    public float minX = -5f;
    public float maxX = 5f; 
    public float spawnHeight = 10f; // y pos that item will drop from
    public float yThreshold = 0f;
    public float lifetime = 5f;

    private List<GameObject> spawnedFlowers = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("flowerSpawn", 0f, spawnInterval);
        // StartCoroutine(DestroyAfterDelay());
    }

        void flowerSpawn()
    {
        // Generate a random X position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Set the spawn position (use fixed Y position for the drop height)
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 5f);

        // Instantiate the item at the random position
        GameObject flower = Instantiate(flowerPrefabs[Random.Range(0, flowerPrefabs.Length)], spawnPosition, Quaternion.identity);
        
    }

        void Update()
    {
        // Check the position of all spawned items each frame
        for (int i = 0; i < spawnedFlowers.Count; i++)
        {
            // If the spawned item is below the threshold, destroy it
            if (spawnedFlowers[i].transform.position.y < yThreshold)
            {
                Destroy(spawnedFlowers[i]);
                spawnedFlowers.RemoveAt(i); // Remove destroyed item from the list
                i--; // Adjust index after removal
            }
        }
    }

    //     IEnumerator DestroyAfterDelay()
    // {
    //     // Wait for the specified amount of time
    //     yield return new WaitForSeconds(lifetime);
        
    //     // Destroy the prefab after the delay
    //     Destroy(gameObject);
    // }

}



