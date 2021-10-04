using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public GameObject startText;
    void Start()
    {
        StartCoroutine(startTextReady());
    }
    IEnumerator startTextReady()
    {
        while (true)
        {
            startText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            startText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
