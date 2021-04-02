using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject[] obstacles;


    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Random.Range(1, 4) == 1)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector3(Random.Range(-100, 100), 100, 0), Quaternion.identity);

        }
    }
}
