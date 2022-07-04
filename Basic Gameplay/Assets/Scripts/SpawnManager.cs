using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animalsPrefabs;
    public KeyCode spawnInput;

    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    private void Update() 
    {
        SpawnAnimals();
    }

    private void SpawnAnimals()
    {
        if(Input.GetKeyDown(spawnInput))
        {
            //Gere aleatoriamente índice de animais e posição de desova
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            int animalIndex = Random.Range(0, animalsPrefabs.Count);
            Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
        }
    }
}
