using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float floatingSpeed;
    private void Start()
    {
        floatingSpeed = Random.Range(0.005f, 0.02f);
    }
    void Update()
    {
        transform.position -= new Vector3(floatingSpeed, 0, 0);
        if(transform.position.x < -4f)
        {
            FindObjectOfType<SpawnerCloud>().newCloud();
            Destroy(gameObject);
        }
    }
}
