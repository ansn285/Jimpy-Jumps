using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Sprite toggleEmpty, toggleFilled;
    [SerializeField] private Image musicToggle, sfxToggle;
    [SerializeField] private Toggle m, s;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        m.isOn = GameController.music;
        //if (musicToggle.transform.parent.GetComponent<Toggle>().isOn)
        //{
        //    musicToggle.sprite = toggleFilled;
        //}
        //else
        //{
        //    musicToggle.sprite = toggleEmpty;
        //}

        s.isOn = GameController.sfx;
        //if (sfxToggle.transform.parent.GetComponent<Toggle>().isOn)
        //{
        //    sfxToggle.sprite = toggleFilled;
        //}
        //else
        //{
        //    sfxToggle.sprite = toggleEmpty;
        //}
    }


    public void ToggleSound()
    {
        //GameController.music = !GameController.music;
        GameController.instance.ToggleMusic(m);

        if (m.isOn)
        {
            musicToggle.sprite = toggleFilled;
        }

        else
        {
            musicToggle.sprite = toggleEmpty;
        }
    }

    public void ToggleSfx()
    {
        //GameController.sfx = !GameController.sfx;
        GameController.instance.ToggleSfx(s);

        if (s.isOn)
        {
            audioSource.Play();
            sfxToggle.sprite = toggleFilled;
        }

        else
        {
            sfxToggle.sprite = toggleEmpty;
        }
    }
}
