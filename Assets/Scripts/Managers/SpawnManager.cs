using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] SpawnObj;
    [SerializeField] float spawnRate;
    [SerializeField] float scaleSpawnRate;
    [SerializeField] float scaleObjSpeed;
    [SerializeField] float spawnX;
    [SerializeField] float spawnY;
    [SerializeField] float scalingInterval=40f;
    private float currentScaleTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScaleLevelDiff(scalingInterval));
        StartCoroutine(RareSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        currentScaleTime+=Time.deltaTime;
    }

    void Spawner(int initialIndex, int finalIndex)
    {
        float randomX = Random.Range(-spawnX,spawnX);
        float randomY = Random.Range(-spawnY,spawnY);
        int randomObjIndex = Random.Range(initialIndex,finalIndex);
        Vector2 randomPos = new Vector2(randomX,randomY);
        Instantiate(SpawnObj[randomObjIndex],randomPos,Quaternion.identity);
    }

    IEnumerator RareSpawnRoutine()
    {
        while(!gameManager.gameOver)
        {
            float waitTime = GetPoissonInterval(0.1f);

            yield return new WaitForSeconds(waitTime);

            Spawner(2,5);
        }
    }

    IEnumerator ScaleLevelDiff(float scaleTime)
    {
        while(!gameManager.gameOver)
        {
            Spawner(0,2);

            if(currentScaleTime>=scaleTime)
            {
                spawnRate*=scaleSpawnRate;
                UpdateSpeed(scaleObjSpeed);
                currentScaleTime=0f;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    float GetPoissonInterval(float lambda)
    {
        float u = Random.value;
        return -Mathf.Log(1 - u) / lambda;
    }

    void UpdateSpeed(float scaleObjSpeed)
    {
        ProjectileScript[] projectiles= FindObjectsByType<ProjectileScript>(FindObjectsSortMode.None);

        foreach(ProjectileScript projectile in projectiles)
        {
            projectile.mspeed*=scaleObjSpeed;
        }
    }
}
