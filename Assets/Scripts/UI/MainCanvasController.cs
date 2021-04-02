using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private Image optionsButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToggleOptionsCanvas()
    {
        if (optionsCanvas.activeSelf)
        {
            optionsCanvas.SetActive(false);
            optionsButton.enabled = true;
        }

        else
        {
            optionsCanvas.SetActive(true);
            optionsButton.enabled = false;
        }
    }

}
