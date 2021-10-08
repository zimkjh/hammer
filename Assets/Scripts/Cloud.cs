using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float floatingSpeed;
    private void Start()
    {
        floatingSpeed = Random.Range(0.007f, 0.025f);
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
