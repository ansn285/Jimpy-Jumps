using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject[] players;
    private float[] distances;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        distances = new float[players.Length];
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistances();
        CalculatePositions();
    }


    void CalculateDistances()
    {
        for (int i = 0; i < players.Length; i++)
        {
            distances[i] = Vector2.Distance(players[i].transform.position, transform.position);
        }
    }


    void CalculatePositions()
    {

        if (GameController.mode == 2)
        {
            if (Mathf.Min(distances[0], distances[1]) == distances[0])
            {
                players[0].GetComponent<CustomPlayer>().Position = 1;
                players[1].GetComponent<CustomPlayer>().Position = 2;
            }

            else
            {
                players[0].GetComponent<CustomPlayer>().Position = 2;
                players[1].GetComponent<CustomPlayer>().Position = 1;
            }
        }


        if (GameController.mode == 3)
        {
            float first, third;
            int second = -1;

            // For first position
            first = Mathf.Min(distances[0], distances[1], distances[2]);
            if (first == distances[0])
            {
                players[0].GetComponent<CustomPlayer>().Position = 1;
            }

            else if (first == distances[1])
            {
                players[1].GetComponent<CustomPlayer>().Position = 1;
            }

            else if (2 < distances.Length - 1 && first == distances[2])
            {
                players[2].GetComponent<CustomPlayer>().Position = 1;
            }

            // For third position
            third = Mathf.Max(distances[0], distances[1], distances[2]);

            if (third == distances[0])
            {
                players[0].GetComponent<CustomPlayer>().Position = 3;
            }

            else if (third == distances[1])
            {
                players[1].GetComponent<CustomPlayer>().Position = 3;
            }

            else if (third == distances[2])
            {
                players[2].GetComponent<CustomPlayer>().Position = 3;
            }

            // For second position
            for (int i = 0; i < players.Length; i++)
            {
                if (distances[i] != first && distances[i] != third)
                {
                    if (second < 0)
                    {
                        second = i;
                        break;
                    }
                }
            }

            if (GameController.mode >= 3)
            {
                players[second].GetComponent<CustomPlayer>().Position = 2;
            }

        }



        if (GameController.mode == 4)
        {
            float first, fourth;
            int second = -1, third = -1;



            // For first position
            first = Mathf.Min(distances[0], distances[1], distances[2], distances[3]);
            if (first == distances[0])
            {
                players[0].GetComponent<CustomPlayer>().Position = 1;
            }

            else if (first == distances[1])
            {
                players[1].GetComponent<CustomPlayer>().Position = 1;
            }

            else if (2 < distances.Length-1 && first == distances[2])
            {
                players[2].GetComponent<CustomPlayer>().Position = 1;
            }

            else if (3 < distances.Length-1 && first == distances[3])
            {
                players[3].GetComponent<CustomPlayer>().Position = 1;
            }



            // For fourth position
            fourth = Mathf.Max(distances[0], distances[1], distances[2], distances[3]);

            if (fourth == distances[0])
            {
                players[0].GetComponent<CustomPlayer>().Position = 4;
            }

            else if (fourth == distances[1])
            {
                players[1].GetComponent<CustomPlayer>().Position = 4;
            }

            else if (2 < distances.Length-1 && fourth == distances[2])
            {
                players[2].GetComponent<CustomPlayer>().Position = 4;
            }

            else if (3 < distances.Length-1 && fourth == distances[3])
            {
                players[3].GetComponent<CustomPlayer>().Position = 4;
            }



            // For second and third positions
            for (int i = 0; i < players.Length; i++)
            {
                if (distances[i] != first && distances[i] != fourth)
                {
                    if (second < 0)
                    {
                        second = i;
                    }

                    else
                    {
                        third = i;
                    }
                }
            }

            if (GameController.mode >= 3)
            {
                if (distances[second] < distances[third])
                {
                    players[second].GetComponent<CustomPlayer>().Position = 2;
                    players[third].GetComponent<CustomPlayer>().Position = 3;
                }

                else
                {
                    players[second].GetComponent<CustomPlayer>().Position = 3;
                    players[third].GetComponent<CustomPlayer>().Position = 2;
                }
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.parent.GetComponent<CheckpointManager>().NextCheckpoint();
        }
    }

}
