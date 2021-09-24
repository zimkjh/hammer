using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    public GameObject block;
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(block, new Vector3(0, 4.7f - 0.5f * i, 0), Quaternion.identity);
        }
    }
    public void newBlock()
    {
        Instantiate(block, new Vector3(0, 4.7f, 0), Quaternion.identity);
    }
}
