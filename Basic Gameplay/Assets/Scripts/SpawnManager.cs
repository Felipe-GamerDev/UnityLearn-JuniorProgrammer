using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animalsPrefabs;

    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private void Start() 
    {
        InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
    }

    private void SpawnAnimals()
    {
        //Gere aleatoriamente índice de animais e posição de desova
        int animalIndex = Random.Range(0, animalsPrefabs.Count);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
    }
}
