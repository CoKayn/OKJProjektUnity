using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject player;
    public GameObject normalEnemy;
    private float distance;
    private float distanceUsed;

    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
        float x = player.transform.position.x;
        distance = (UnityEngine.Random.Range(0.000001f, 10f) * 20) + x; // 20 helyett 50 volt alapból  // distance = (UnityEngine.Random.Range(0.000001f, 1f) * 50) + x;


        GameObject[] gameObjects  = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameObjects.Length < 200)   // 30 
        {

        SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = SelectEnemyToSpawn();
        float yPos = Mathf.Floor(f: Mathf.Abs(f: UnityEngine.Random.Range(0f, 6f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 5 - (-2)) + (-2));  
        //  float yPos = Mathf.Floor(f: Mathf.Abs(f: UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 100 - (-2)) + (-2));
        yPos = yPos < 0 ? 1 : yPos;
        Vector2 posToSpawnEnemy = new Vector2(x: distance, yPos);
        Instantiate(enemyToSpawn, posToSpawnEnemy, Quaternion.identity);
    }
    private GameObject SelectEnemyToSpawn()
    {
        return normalEnemy;
    }
}
