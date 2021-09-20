using UnityEngine.SceneManagement;
using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SelectGameMode(int mode)
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        GameController.mode = mode;

        // Loading the lobby scene
        SceneManager.LoadScene(1);
    }
}
