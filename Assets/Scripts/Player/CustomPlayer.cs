using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomPlayer : MonoBehaviour
{
    private string playerName;
    private int position;
    private Sprite sprite;
    private TextMeshProUGUI nameText, positionText;
    private Dictionary<int, string> positionsDictionary = new Dictionary<int, string>();

    [System.NonSerialized] public KeyCode up, down, left, right, change, use;
    

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;

            positionText.text = positionsDictionary[position];
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }


    private void Start()
    {
        positionsDictionary.Add(1, "1st");
        positionsDictionary.Add(2, "2nd");
        positionsDictionary.Add(3, "3rd");
        positionsDictionary.Add(4, "4th");
        positionsDictionary.Add(5, "5th");
        positionsDictionary.Add(6, "6th");
        positionsDictionary.Add(7, "7th");
        positionsDictionary.Add(8, "8th");
        positionsDictionary.Add(9, "9th");
        positionsDictionary.Add(10, "10th");


        nameText = transform.Find("Canvas (1)").Find("Name").GetComponent<TextMeshProUGUI>();
        positionText = transform.Find("Canvas (1)").Find("Position").GetComponent<TextMeshProUGUI>();

        nameText.text = playerName;
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        

        if (position >= 1 && position <= 10)
        {
            positionText.text = positionsDictionary[position];
        }
    }

    public void UpdateKeyBindings(KeyCode[] keys)
    {
        this.up = keys[0];
        this.down = keys[1];
        this.left = keys[2];
        this.right = keys[3];
        this.change = keys[4];
        this.use = keys[5];
    }


    public int GetKeyDown(KeyCode k)
    {
        if (k == use || k == change || k == up || k == right)
        {
            return 1;
        }

        if (k == down || k == left)
        {
            return -1;
        }

        return 0;
    }

    public int GetAxis(string axis, bool k1, bool k2)
    {
        if (axis == "Horizontal")
        {
            if (k1)
            {
                return -1;
            }

            else if (k2)
            {
                return 1;
            }
        }

        else if (axis == "Vertical")
        {

            if (k1)
            {
                return 1;
            }

            else if (k2)
            {
                return -1;
            }
        }

        return 0;
    }

    public KeyCode[] GetKeyBindings()
    {
        return new KeyCode[] { up, down, left, right, change, use };
    }

    public override string ToString()
    {
        return "Name: " + playerName +
                "\nUp: " + up.ToString() +
                "\nDown: " + down.ToString() +
                "\nLeft: " + left.ToString() +
                "\nRight: " + right.ToString() +
                "\nChange: " + change.ToString() +
                "\nUse: " + use.ToString();
    }

}