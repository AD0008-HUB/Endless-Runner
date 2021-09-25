using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    public GameObject[] obstaclePattern;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn = 3f;
    public float decreaseTime = 0.05f;
    public float minTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn <=0)
        {
            int random = Random.Range(0, obstaclePattern.Length);
            Instantiate(obstaclePattern[random], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime) // time will not be decreased beyond this
            {
                startTimeBtwSpawn -= decreaseTime;  //decrease the time making the game faster
            }

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
