using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject levelEndCanvas; 
    [SerializeField] private GameObject[] confettiParticles;

    private int playerCount = 0;
    private Dictionary<int, string> players = new Dictionary<int, string>();
    private Sprite[] playerSprites = new Sprite[GameController.mode];
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSprites[playerCount] = collision.gameObject.GetComponent<CustomPlayer>().Sprite;
            players.Add(playerCount, collision.GetComponent<CustomPlayer>().PlayerName);

            playerCount++;

            collision.GetComponent<PlayerController>().enabled = false;
            collision.GetComponent<Animator>().SetFloat("walk", 0);
            collision.GetComponent<Rigidbody2D>().drag = 1.25f;

            if (playerCount == 1)
            {
                if (GameController.sfx)
                {
                    audioSource.Play();
                }

                confettiParticles[0].SetActive(true);
                confettiParticles[1].SetActive(true);
            }

            if (playerCount == GameController.mode)
            {
                Cursor.visible = true;
                GameController.instance.audioSource.volume = .2f;
                levelEndCanvas.SetActive(true);
                levelEndCanvas.GetComponent<LevelEndManager>().SetupPositions(players, playerSprites);
            }
        }
    }

}
