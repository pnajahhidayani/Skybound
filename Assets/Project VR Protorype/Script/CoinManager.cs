using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    private float zSpawn = 0;
    private float xSpawn = 0;
    private float ySpawn = 0;
    private float coinLength = 30;
    public int numberOfCoins = 5;
    public Transform playerTransform;
    private List<GameObject> activeCoins = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        xSpawn = Random.Range(-10, -2.73f);
        ySpawn = 0.63f;
        
        for (int i = 0; i < numberOfCoins; i++)
        {
            if (i == 0)
            {
                spawnCoin(0);
            }
            else
            {
                spawnCoin(Random.Range(0, coinPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfCoins * coinLength))
        {
            spawnCoin(Random.Range(0, coinPrefabs.Length));
            DeleteCoin();
        }
    }

    public void spawnCoin(int coinIndex)
    {
        GameObject go = Instantiate(coinPrefabs[coinIndex], new Vector3(xSpawn, ySpawn, zSpawn), transform.rotation);
        activeCoins.Add(go);
        zSpawn += coinLength;
        xSpawn = Random.Range(-10, -2.73f);
    }

    private void DeleteCoin()
    {
        Destroy(activeCoins[0]);
        activeCoins.RemoveAt(0);
    }
}
