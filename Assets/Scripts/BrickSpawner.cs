using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject brickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int hrow = 5;
        int vrow = 5;
        Vector3 brickSize = brickPrefab.transform.localScale;

        // Vertical bricks loop
        for (int i=0; i < vrow; i++)
        {
            // Last brick position cache
            Vector3 lastBrickPos = Vector3.zero;

            // Horizontal bricks loop
            for (int j = 0; j < hrow; j++)
            {
                // Calculate position for new brick
                Vector3 position = transform.position + new Vector3(brickSize.x + lastBrickPos.x, 0, brickSize.z * -i);

                // Instantiate new brick within spawner parent
                GameObject brick = Instantiate(brickPrefab, transform);
                brick.transform.position = position;

                // Update cache for last brick
                lastBrickPos = position;
            }
        }

        // Align bricks spawner
        transform.position -= new Vector3(brickPrefab.transform.localScale.x + hrow, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
