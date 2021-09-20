using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject pauseMenu;

    private string[] characterNames;
    private Dictionary<string, GameObject> characters = new Dictionary<string, GameObject>();
    private AudioSource audioSource;

    private void Awake()
    {
        Cursor.visible = false;
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characters.Add(characterPrefabs[i].name, characterPrefabs[i]);
        }

        audioSource = GetComponent<AudioSource>();
        SetupLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            GameController.instance.audioSource.volume = pauseMenu.activeInHierarchy ? .2f : 1f;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            Cursor.visible = pauseMenu.activeInHierarchy ? true : false;
        }
    }

    private void SetupLevel()
    {
        if (GameController.mode == 2)
        {
            GameObject player1 = Instantiate(characters[GameController.p1Character], spawnPoints[0].position, Quaternion.identity);
            GameObject player2 = Instantiate(characters[GameController.p2Character], spawnPoints[1].position, Quaternion.identity);


            player1.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[0];
            player1.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p1);
            player1.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, 0.5f),
                                                                                        new Vector2(1f, 0.5f));

            player2.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, 0f),
                                                                                        new Vector2(1f, 0.5f));
            player2.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[1];
            player2.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p2);
        }

        if (GameController.mode == 3)
        {
            GameObject player1 = Instantiate(characters[GameController.p1Character], spawnPoints[0].position, Quaternion.identity);
            GameObject player2 = Instantiate(characters[GameController.p2Character], spawnPoints[1].position, Quaternion.identity);
            GameObject player3 = Instantiate(characters[GameController.p3Character], spawnPoints[2].position, Quaternion.identity);


            player1.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[0];
            player1.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p1);
            player1.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, .5f),
                                                                                        new Vector2(.5f, .5f));


            player2.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[1];
            player2.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p2);
            player2.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(.5f, .5f),
                                                                                        new Vector2(.5f, .5f));

            player3.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[2];
            player3.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p3);
            player3.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, 0f),
                                                                                        new Vector2(1f, .5f));
        }

        if (GameController.mode == 4)
        {

            GameObject player1 = Instantiate(characters[GameController.p1Character], spawnPoints[0].position, Quaternion.identity);
            GameObject player2 = Instantiate(characters[GameController.p2Character], spawnPoints[1].position, Quaternion.identity);
            GameObject player3 = Instantiate(characters[GameController.p3Character], spawnPoints[2].position, Quaternion.identity);
            GameObject player4 = Instantiate(characters[GameController.p4Character], spawnPoints[3].position, Quaternion.identity);


            player1.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[0];
            player1.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p1);
            player1.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, .5f),
                                                                                        new Vector2(.5f, .5f));

            player2.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[1];
            player2.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p2);
            player2.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(.5f, .5f),
                                                                                        new Vector2(.5f, .5f));

            player3.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[2];
            player3.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p3);
            player3.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(0f, 0f),
                                                                                        new Vector2(.5f, .5f));

            player4.GetComponent<CustomPlayer>().PlayerName = GameController.playerNames[3];
            player4.GetComponent<CustomPlayer>().UpdateKeyBindings(GameController.p4);
            player4.transform.Find("Main Camera").GetComponent<Camera>().rect = new Rect(new Vector2(.5f, 0f),
                                                                                        new Vector2(.5f, .5f));
        }
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;


        GameController.instance.audioSource.volume = 1f;
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        pauseMenu.SetActive(false);
    }

    public void LoadMainMenu()
    {
        ResumeGame();
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }


    public void RestartGame()
    {
        ResumeGame();
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
