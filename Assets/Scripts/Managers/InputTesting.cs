using UnityEngine;
using UnityEngine.UI;

public class InputTesting : MonoBehaviour
{
    public Button w, a, s, d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            d.interactable = true;
            a.interactable = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            d.interactable = false;
            a.interactable = true;
        }
        else
        {
            d.interactable = false;
            a.interactable = false;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            w.interactable = true;
            s.interactable = false;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            w.interactable = false;
            s.interactable = true;
        }
        else
        {
            w.interactable = false;
            s.interactable = false;
        }
    }
}
