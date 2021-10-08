using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    private int blockNumber = 18;
    public GameObject block;
    void Start()
    {
        for (int i = 0; i < blockNumber; i++)
        {
            Instantiate(block, new Vector3(0, 5f - 0.4f * i, 0), Quaternion.identity);
        }
    }
    public void newBlock()
    {
        Instantiate(block, new Vector3(0, 5f, 0), Quaternion.identity);
    }
}
