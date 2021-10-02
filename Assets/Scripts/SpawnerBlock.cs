using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    public int blockNumber = 15;
    public GameObject block;
    void Start()
    {
        for (int i = 0; i < blockNumber; i++)
        {
            Instantiate(block, new Vector3(0, 4.7f - 0.5f * i, 0), Quaternion.identity);
        }
    }
    public void newBlock()
    {
        Instantiate(block, new Vector3(0, 4.7f, 0), Quaternion.identity);
    }
}
