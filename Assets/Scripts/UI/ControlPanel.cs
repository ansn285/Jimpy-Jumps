using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] player1, player2, player3, player4;
    private bool isChanging = false;
    private Button currentButton = null;
    private KeyCode[] p1, p2, p3, p4;
    
    private int changeIndex = 0, currentPlayer = 0;
    
    private Dictionary<int, KeyCode[]> dict;
    private Dictionary<string, int> directionIndex;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        p1 = GameController.p1;
        p2 = GameController.p2;
        p3 = GameController.p3;
        p4 = GameController.p4;

        dict = new Dictionary<int, KeyCode[]>();
        dict.Add(1, p1);
        dict.Add(2, p2);
        dict.Add(3, p3);
        dict.Add(4, p4);

        directionIndex = new Dictionary<string, int>();
        directionIndex.Add("up", 0);
        directionIndex.Add("down", 1);
        directionIndex.Add("left", 2);
        directionIndex.Add("right", 3);
        directionIndex.Add("change", 4);
        directionIndex.Add("use", 5);

        UpdateControls();
    }


    private void UpdateControls()
    {
        for (int i = 0; i < player1.Length; i++)
        {
            if (GameController.p1[i].ToString().Contains("Arrow"))
            {
                player1[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p1[i].ToString().Replace("Arrow", "");
            }
            else
            {
                player1[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p1[i].ToString();
            }

            if (GameController.p2[i].ToString().Contains("Arrow"))
            {
                player2[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p2[i].ToString().Replace("Arrow", "");
            }
            else
            {
                player2[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p2[i].ToString();
            }

            if (GameController.p3[i].ToString().Contains("Arrow"))
            {
                player3[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p3[i].ToString().Replace("Arrow", "");

            }
            else
            {
                player3[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p3[i].ToString();
            }

            if (GameController.p4[i].ToString().Contains("Arrow"))
            {
                player4[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p4[i].ToString().Replace("Arrow", "");
            }
            else
            {
                player4[i].transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = GameController.p4[i].ToString();
            }
        }
    }


    private void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && isChanging)
        {
            currentButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();

            isChanging = false;

            UpdateControls();
            UpdateKeyBindings(e.keyCode);
            EnableAllButtons();
        }
    }


    public void KeysChanged(Button btn)
    {
        if (GameController.sfx)
        {
            audioSource.Play();
        }

        btn.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "";

        isChanging = true;
        currentButton = btn;
        currentPlayer = int.Parse(btn.transform.parent.name[0].ToString());

        SetChangeIndex(btn);
        DisableAllButtons();
    }




    private void DisableAllButtons()
    {
        for (int i = 0; i < player1.Length; i++)
        {
            player1[i].GetComponent<Button>().interactable = false;
            player2[i].GetComponent<Button>().interactable = false;
            player3[i].GetComponent<Button>().interactable = false;
            player4[i].GetComponent<Button>().interactable = false;
        }
    }


    private void EnableAllButtons()
    {
        for (int i = 0; i < player1.Length; i++)
        {
            player1[i].GetComponent<Button>().interactable = true;
            player2[i].GetComponent<Button>().interactable = true;
            player3[i].GetComponent<Button>().interactable = true;
            player4[i].GetComponent<Button>().interactable = true;
        }
    }


    void UpdateKeyBindings(KeyCode k)
    {
        dict[currentPlayer][changeIndex] = k;

        GameController.UpdateKeyBindings(dict);
    }


    private void SetChangeIndex(Button btn)
    {
        changeIndex = directionIndex[btn.name];
    }

}