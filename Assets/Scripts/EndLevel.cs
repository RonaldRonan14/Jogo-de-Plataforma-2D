using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI scoreText;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckEndOrNext();
        }
    }

    void CheckEndOrNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        AudioManager.instance.PlaySFX(AudioManager.instance.victory);

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            ShowVictoryPanel();
        }
    }

    void ShowVictoryPanel()
    {
        if (endPanel != null)
        {

            Debug.Log("Teste");
            scoreText.text = GameController.instance.GetScore().ToString().PadLeft(4, '0');

            endPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
