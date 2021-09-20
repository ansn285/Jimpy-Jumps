using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static int mode = 2;
    public static bool music = true, sfx = true;
    public static string p1Character = "Circle",
        p2Character = "Circle", p3Character = "Circle", p4Character = "Circle";


    public static KeyCode[] p1, p2, p3, p4;
    public static string[] playerNames;
    public AudioSource audioSource;


    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        p1 = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Q, KeyCode.E };
        p2 = new KeyCode[] { KeyCode.T, KeyCode.G, KeyCode.F, KeyCode.H, KeyCode.R, KeyCode.Y };
        p3 = new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L, KeyCode.U, KeyCode.O };
        p4 = new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Delete, KeyCode.PageDown };

        playerNames = new string[4] { "P1", "P2", "P3", "P4" };
        audioSource = GetComponent<AudioSource>();

        if (music)
        {
            audioSource.Play();
        }
    }


    public static void UpdateKeyBindings(Dictionary<int, KeyCode[]> dict)
    {
        p1 = dict[1];
        p2 = dict[2];
        p3 = dict[3];
        p4 = dict[4];
    }


    public void ToggleMusic(Toggle t)
    {
        music = t.isOn;

        if (audioSource && music)
        {
            audioSource.Play();
        }

        else if (audioSource)
        {
            audioSource.Stop();
        }
    }


    public void ToggleSfx(Toggle t)
    {
        sfx = t.isOn;
    }

}
