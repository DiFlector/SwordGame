using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject currectEnemy;
    public int difficulty = 1, spawnCount = 0;
    public GameObject[] enemys;
    private float enemyX, enemyY, angle = 0f, height = 0f;

    void Start()
    {
        InvokeRepeating("difficultyUp", 0f, 1f);
        InvokeRepeating("Spawn", 0f, 1.2f);
        InvokeRepeating("SpawnCountUp", 0f, 90f);
    }
    void difficultyUp()
    {
        difficulty ++;
    }
    void SpawnCountUp()
    {
        spawnCount++;
    }
    void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            angle = Random.Range(0f, 360f);
            enemyX = transform.position.x + Mathf.Cos(angle) * 25f;
            enemyY = transform.position.y + Mathf.Sin(angle) * 25f;

            var rand = Random.Range(0, difficulty);

            if (rand <= 180)
            {
                currectEnemy = enemys[0];
                height = 0.7f;
            }
            if (rand > 180 && rand <= 360)
            {
                currectEnemy = enemys[1];
                height = 0.27f;
            }

            currectEnemy.transform.position = new Vector3(enemyX, height, enemyY);
            Instantiate(currectEnemy);

            if (rand <= 720)
            {
                currectEnemy = enemys[2];
                height = 0.3f;
                currectEnemy.transform.position = new Vector3(enemyX, height, enemyY);
                Instantiate(currectEnemy);
            }
        }
    }
}
