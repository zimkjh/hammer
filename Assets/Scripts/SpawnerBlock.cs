using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    private int blockNumber = 16;
    public GameObject block;
    void Start()
    {
        for (int i = 0; i < blockNumber; i++)
        {
            Instantiate(block, new Vector3(0, 5.2f - 0.5f * i, 0), Quaternion.identity);
        }
    }
    public void newBlock()
    {
        Instantiate(block, new Vector3(0, 5.2f, 0), Quaternion.identity);
    }
}
