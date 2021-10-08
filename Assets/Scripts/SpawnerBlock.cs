using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    private int blockNumber = 19;
    private float blockStartY = 5.4f;
    public GameObject block;
    void Start()
    {
        for (int i = 0; i < blockNumber; i++)
        {
            Instantiate(block, new Vector3(0, blockStartY - 0.4f * i, 0), Quaternion.identity);
        }
    }
    public void newBlock()
    {
        Instantiate(block, new Vector3(0, blockStartY, 0), Quaternion.identity);
    }
}
