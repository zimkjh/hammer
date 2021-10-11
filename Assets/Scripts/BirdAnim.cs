using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnim : MonoBehaviour
{
    public static BirdAnim I;
    public Sprite bird0_end;
    public Sprite bird1_end;
    public Sprite bird100_end;
    public Sprite bird101_end;
    private void Awake()
    {
        I = this;
    }
    public void birdEating(string birdNumber)
    {
        GameObject.Find("bird" + birdNumber).GetComponent<Animator>().SetInteger("condition", 1);
    }
    public void feverBird(bool isFever)
    {
        GameObject.Find("bird" + 0).GetComponent<Renderer>().enabled = !isFever;
        GameObject.Find("bird" + 1).GetComponent<Renderer>().enabled = !isFever;
        GameObject.Find("bird" + 100).GetComponent<Renderer>().enabled = isFever;
        GameObject.Find("bird" + 101).GetComponent<Renderer>().enabled = isFever;
    }
    public void gameOverBird()
    {
        GameObject.Find("bird" + 0).GetComponent<Animator>().enabled = false;
        GameObject.Find("bird" + 1).GetComponent<Animator>().enabled = false;
        GameObject.Find("bird" + 0).GetComponent<SpriteRenderer>().sprite = bird0_end;
        GameObject.Find("bird" + 1).GetComponent<SpriteRenderer>().sprite = bird1_end;
    }
}
