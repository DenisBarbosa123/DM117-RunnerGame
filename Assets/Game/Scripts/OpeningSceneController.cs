using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneController : MonoBehaviour
{
    public float delay = 3f; // Tempo em segundos para exibir a tela de abertura
    public string nextSceneName = "Game"; // Nome da cena principal

    void Start()
    {
        // Inicia a contagem regressiva para carregar a próxima cena
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        // Aguarda pelo tempo especificado
        yield return new WaitForSeconds(delay);

        // Carrega a cena principal
        SceneManager.LoadScene(nextSceneName);
    }
}
