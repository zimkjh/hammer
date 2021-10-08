using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCloud : MonoBehaviour
{
    public GameObject[] cloudList;
    void Start()
    {
        Instantiate(cloudList[Random.Range(0, cloudList.Length)], new Vector3(4, Random.Range(-1.4f, 1f), 0), Quaternion.identity);
        Instantiate(cloudList[Random.Range(0, cloudList.Length)], new Vector3(6, Random.Range(-1.4f, 1f), 0), Quaternion.identity);
    }
    public void newCloud()
    {
        Instantiate(cloudList[Random.Range(0, cloudList.Length)], new Vector3(4, Random.Range(-1.4f, 1f), 0), Quaternion.identity);
    }
}
