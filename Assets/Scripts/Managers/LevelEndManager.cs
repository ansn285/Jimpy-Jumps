using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEndManager : MonoBehaviour
{
    [SerializeField] private GameObject[] positionsElements;

    public void SetupPositions(Dictionary<int, string> players, Sprite[] playersSprites)
    {
        for (int i = 0; i < playersSprites.Length; i++)
        {
            positionsElements[i].SetActive(true);
            positionsElements[i].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = players[i];
            positionsElements[i].transform.Find("Image").GetComponent<Image>().sprite = playersSprites[i];
        }
    }
}
