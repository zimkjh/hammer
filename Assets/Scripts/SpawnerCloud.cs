using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCloud : MonoBehaviour
{
    public GameObject[] cloudList;
    void Start()
    {
        Instantiate(cloudList[Random.Range(0, cloudList.Length)], new Vector3(4, Random.Range(-2f, -1f), 0), Quaternion.identity);
    }

    void Update()
    {
        Debug.Log(transform.position);// TODO : move cloud!!
        transform.position -= new Vector3(Random.Range(0f, 0.5f), 0, 0);
    }
}
