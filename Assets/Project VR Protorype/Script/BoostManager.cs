using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public GameObject[] boostPrefabs;
    private float zSpawn = 0;
    private float xSpawn = 0;
    private float ySpawn = 0;
    private float boostLength = 70;
    public int numberOfBoosts = 1;
    public Transform playerTransform;
    private List<GameObject> activeBoosts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        xSpawn = Random.Range(-10, -2.73f);
        ySpawn = 0.63f;
        
        for (int i = 0; i < numberOfBoosts; i++)
        {
            if (i == 0)
            {
                spawnBoost(0);
            }
            else
            {
                spawnBoost(Random.Range(0, boostPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfBoosts * boostLength))
        {
            spawnBoost(Random.Range(0, boostPrefabs.Length));
            DeleteBoost();
        }
    }

    public void spawnBoost(int boostIndex) {
        GameObject go = Instantiate(boostPrefabs[0], new Vector3(xSpawn, ySpawn, zSpawn), transform.rotation);
        activeBoosts.Add(go);
        zSpawn += boostLength;
        xSpawn = Random.Range(-10, -2.73f);
    }

    private void DeleteBoost()
    {
        Destroy(activeBoosts[0]);
        activeBoosts.RemoveAt(0);
    }
}
