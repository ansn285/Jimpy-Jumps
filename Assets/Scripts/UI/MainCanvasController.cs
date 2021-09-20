using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas, modesCanvas;
    [SerializeField] private Image optionsButton, menuBtnImage;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ToggleOptionsCanvas()
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }


        if (optionsCanvas.activeSelf)
        {
            optionsCanvas.SetActive(false);
            optionsButton.enabled = true;
        }

        else
        {
            optionsCanvas.SetActive(true);
            optionsButton.enabled = false;

            modesCanvas.SetActive(false);
            menuBtnImage.enabled = true;
        }
    }


    public void ToggleModeCanvas()
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        if (modesCanvas.activeSelf)
        {
            modesCanvas.SetActive(false);
            menuBtnImage.enabled = true;
        }

        else
        {
            modesCanvas.SetActive(true);
            menuBtnImage.enabled = false;

            optionsCanvas.SetActive(false);
            optionsButton.enabled = true;
        }
    }




    public void LoadLobby()
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
