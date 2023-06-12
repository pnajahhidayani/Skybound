using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float zSpawn = 0;
    private float xSpawn = 0;
    private float ySpawn = 0;
    private float enemyLength = 30;
    public int numberOfEnemies = 5;
    public Transform playerTransform;
    private List<GameObject> activeEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        xSpawn = Random.Range(-9, -16);
        ySpawn = 2.79f;
        
        for (int i = 0; i < numberOfEnemies; i++)
        {
            if (i == 0)
            {
                spawnEnemies(0);
            }
            else
            {
                spawnEnemies(Random.Range(0, enemyPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfEnemies * enemyLength))
        {
            spawnEnemies(Random.Range(0, enemyPrefabs.Length));
            DeleteEnemy();
        }
    }

    public void spawnEnemies(int enemyIndex)
    {
        GameObject go = Instantiate(enemyPrefabs[enemyIndex], new Vector3(xSpawn, ySpawn, zSpawn), transform.rotation);
        activeEnemies.Add(go);
        zSpawn += enemyLength;
        xSpawn = Random.Range(-9, -16);
    }

    private void DeleteEnemy()
    {
        Destroy(activeEnemies[0]);
        activeEnemies.RemoveAt(0);
    }
}
