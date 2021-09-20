using UnityEngine.UI;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public Image selectedMap;
    public Sprite[] mapNames = null;
    public Color32[] colors;
    public GameObject mapButton, mainPanel, mapPanel;

    public int Xo, Yo, dy;


    private void Start()
    {
        for (int i = 0; i < mapNames.Length; i++)
        {
            var btn = Instantiate(mapButton);
            btn.transform.Find("Image").GetComponent<Image>().sprite = mapNames[i];
            btn.transform.SetParent(gameObject.transform);
            btn.name = "MapBtn " + (i);
            btn.GetComponent<Image>().color = colors[i];
            btn.GetComponent<Button>().onClick.AddListener(delegate() { ChangeSelectedMap(btn.name); });

            if (i % 2 == 0)
            {
                btn.GetComponent<RectTransform>().localPosition = new Vector3(Xo, Yo, 0);
            }

            else
            {
                btn.GetComponent<RectTransform>().localPosition = new Vector3(Xo * -1, Yo, 0);
                Yo -= dy;
            }
        }
    }


    private void ChangeSelectedMap(string name)
    {
        int mapNumber = int.Parse(name.Split(' ')[1]);
        selectedMap.sprite = mapNames[mapNumber];
        mainPanel.SetActive(true);
        mapPanel.SetActive(false);
    }

}
