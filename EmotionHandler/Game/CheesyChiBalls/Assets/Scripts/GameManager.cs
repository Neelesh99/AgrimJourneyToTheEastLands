using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Player player;
    GameObject[] allGameObjects;
    public int numLayers = 4;
    public float sceneSpeed;
    private float enemyTimeCount = 0f,
        mountainTimeCount = 0f,
        cloudTimeCount = 0f;
    //public static float Range(float min, float max);
    private int spawnNumber = 0;
    public GameObject monsterHappy, monsterSad, monsterAnger, monsterNeutral,
        mountain,
        cloud;

    public float enemySpawnFreq,
        mountainSpawnFreq,
        cloudSpawnFreq;
    public int level;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        if (level == 0)
        {
            level = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimeCount += Time.deltaTime;

        if (level == 1)
        {
            enemySpawnFreq = 0.4f;
            if (enemyTimeCount >= 1 / enemySpawnFreq)
            {
                enemyTimeCount = 0;
                spawnNumber += 1;
                Instantiate(monsterHappy, new Vector2(10f, 4.2f * Mathf.Sin(spawnNumber * 0.2f * Mathf.PI)), Quaternion.identity);
            }

        }

        if (level == 2)
        {
            enemySpawnFreq = 0.8f;
            if (enemyTimeCount >= 1 / enemySpawnFreq)
            {
                enemyTimeCount = 0;
                spawnNumber += 1;
                Instantiate(monsterSad, new Vector2(10f, 5), Quaternion.identity);//Random.Range(-20f,4.2f)), Quaternion.identity);
                //SleepTimeout(10);
                Instantiate(monsterHappy, new Vector2(10f, 4.2f * Mathf.Sin(spawnNumber * 0.2f * Mathf.PI)), Quaternion.identity);
            }

        }

        if (level == 3)
        {
            enemySpawnFreq = 1;
            if (enemyTimeCount >= 1 / enemySpawnFreq)
            {
                enemyTimeCount = 0;
                spawnNumber += 1;
                Instantiate(monsterAnger, new Vector2(10f, Random.Range(-4f, 4f)), Quaternion.identity);
            }

        }

        if (level == 4)
        {
            enemySpawnFreq = 1.2f;
            if (enemyTimeCount >= 1 / enemySpawnFreq)
            {
                enemyTimeCount = 0;
                spawnNumber += 1;
                Instantiate(monsterNeutral, new Vector2(10f, Random.Range(-4f, 4f)), Quaternion.identity);
            }

        }

        mountainTimeCount += Time.deltaTime;
        if (mountainTimeCount >= 1 / (0.1 * mountainSpawnFreq))
        {
            float mountainOffset = Random.Range(5.0f, 10f);
            mountainTimeCount = 0;
            Instantiate(mountain, new Vector2(10f + mountainOffset, -0.71f), Quaternion.identity);
        }

        cloudTimeCount += Time.deltaTime;
        if (cloudTimeCount >= 1 / (0.1 * cloudSpawnFreq))
        {
            float cloudXOffset = Random.Range(5.0f, 8.0f);
            float cloudYOffset = Random.Range(2f, 4f);
            cloudTimeCount = 0f;
            Instantiate(cloud, new Vector2(5f + cloudXOffset, cloudYOffset), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.moveUp();
            Debug.Log("Moving Up");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player.moveDown();
            Debug.Log("Moving Down");
        }
    }

}
