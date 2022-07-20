using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Script para controlar o Spawn de objetos em cena. Aplicações na UI, como game over, pontuação, start game e reiniciar.

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject background;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    private int score;

    private void Start() 
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UptadeScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        //Minha lógica pra deixar o UI melhor
        scoreText.gameObject.SetActive(false);
        background.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {  
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        
        spawnRate /= difficulty; //Essa aplicação controla a quantidade de objetos spawnados em cada dificuldade

        scoreText.gameObject.SetActive(true); //Minha lógica pra deixar o UI melhor
        background.SetActive(true); //Minha lógica pra deixar o UI melhor

        StartCoroutine(SpawnTarget());
        UptadeScore(0);
    }
}
