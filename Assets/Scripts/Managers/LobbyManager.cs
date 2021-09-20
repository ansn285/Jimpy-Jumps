using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject p2, p3, p4;
    [SerializeField] private Image mapBtn;

    private TMP_InputField currentField;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void CurrentField(TMP_InputField field)
    {
        currentField = field;
    }

    
    private void Awake()
    {
        SetupCanvas(GameController.mode);
    }



    private void SetupCanvas(int count)
    {
        if (count == 2)
        {
            p2.SetActive(true);
        }

        else if (count == 3)
        {
            p3.SetActive(true);
        }

        else if (count == 4)
        {
            p4.SetActive(true);
        }
    }


    public void StartGame()
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        SceneManager.LoadScene("Level " + mapBtn.sprite.name);
    }


    public void MainMenu()
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        SceneManager.LoadScene(0);
    }


    public void InputChanged(int playerNumber)
    {
        if (currentField.text != "")
        {
            GameController.playerNames[playerNumber - 1] = currentField.text;
        }
    }
}
