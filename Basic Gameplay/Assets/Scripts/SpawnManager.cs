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
    [SerializeField] private float sideSpawnMinZ = 3;
    [SerializeField] private float sideSpawnMaxZ = 15;
    [SerializeField] private float sideSpawnX = 20;

    private void Start() 
    {
        // O +3, +2 é uma forma simples de controla a dificuldade dentro de jogo.
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimals", startDelay + 3, spawnInterval + 3); 
        InvokeRepeating("SpawnRightAnimals", startDelay + 2, spawnInterval + 3);
    }

    private void SpawnRandomAnimals()
    {
        //Gere aleatoriamente índice de animais e posição de desova
        int animalIndex = Random.Range(0, animalsPrefabs.Count);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
    }

    private void SpawnLeftAnimals()
    {
        int animalIndex = Random.Range(0, animalsPrefabs.Count);

        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));

        Vector3 rotation = new Vector3(0, 90, 0);

        Instantiate(animalsPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    private void SpawnRightAnimals()
    {
        int animalIndex = Random.Range(0, animalsPrefabs.Count);

        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));

        Vector3 rotation = new Vector3(0, -90, 0);

        Instantiate(animalsPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
