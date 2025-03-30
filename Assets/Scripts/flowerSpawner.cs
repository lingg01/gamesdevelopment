using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] flowerPrefabs;
    [SerializeField] float secondSpawn = 10f;
    [SerializeField] float minFlower;
    [SerializeField] float maxFlower;
    public Vector3 minVector;
    public Vector3 maxVector;
    public Vector3 randomVector;

    // Start is called before the first frame update
    void Start()
    {
        minVector = new Vector3(0, 500, 0);
        maxVector = new Vector3(500, 500, 0);
        randomVector = new Vector3 (
            Random.Range(minVector.x, maxVector.x),
            Random.Range(minVector.y, maxVector.y),
            Random.Range(minVector.z, maxVector.z)
        );

        StartCoroutine(flowerSpawn());
    }

IEnumerator flowerSpawn()
{
    for (int i = 0; i < 50; i++)
    {
        var wanted = Random.Range(minFlower, maxFlower);
        var position = new Vector3 (wanted, transform.position.y);
        GameObject gameObject = Instantiate(flowerPrefabs[Random.Range(0, flowerPrefabs.Length)], randomVector, Quaternion.identity);
        yield return new WaitForSeconds(secondSpawn);
        Destroy(gameObject, 10f);
    }
}

}
