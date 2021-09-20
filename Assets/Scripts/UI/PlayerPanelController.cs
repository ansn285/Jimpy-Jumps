using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerPanelController : MonoBehaviour
{
    [SerializeField] private Button[] characterButtons;
    [SerializeField] private int playerNumber;


    public void CharacterSelected(Button button)
    {
        foreach (Button b in characterButtons)
        {
            if (b != button)
            {
                b.interactable = true;
                b.transform.Find("Image").gameObject.SetActive(false);
            }
        }

        button.interactable = false;
        button.transform.Find("Image").gameObject.SetActive(true);

        if (playerNumber == 1)
        {
            GameController.p1Character = button.gameObject.name;
        }

        else if (playerNumber == 2)
        {
            GameController.p2Character = button.gameObject.name;
        }

        else if (playerNumber == 3)
        {
            GameController.p3Character = button.gameObject.name;
        }

        else if (playerNumber == 4)
        {
            GameController.p4Character = button.gameObject.name;
        }
    }

    
}
