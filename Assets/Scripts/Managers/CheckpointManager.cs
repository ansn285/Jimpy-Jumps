using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints;
    private int index;


    public void NextCheckpoint()
    {
        if (index < checkpoints.Length-1)
        {
            checkpoints[index].SetActive(false);
            checkpoints[index + 1].SetActive(true);
            index++;
        }
    }

}
