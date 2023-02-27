using System.Collections;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameControllerScript gc;
    public GameObject collectable;

    private float[] zOffset = new float[3] { -3.3f, 0f, 3.3f };
    private float[] yOffset = new float[2] { 0.5f, 2.5f };
    private float spawnCollisionCheckRadius = 3;
    private Vector3 dimangiSpawnPoint;
    public int gems;


    public void StartSpawning()
    {
        gems = 0;
        SpawnDimangi();
        StartCoroutine(CollectableCoroutine());
    }

    public void SetDimangiSpawnPoint()
    {
        int randomHorizontal = Random.Range(0, 3);
        int randomVertical = Random.Range(0, 2);
        float newZPosition = zOffset[randomHorizontal];
        float newYPosition = yOffset[randomVertical];
        dimangiSpawnPoint = new Vector3(-100f, newYPosition, newZPosition);
    }


    public void SpawnDimangi()
    {
        SetDimangiSpawnPoint();
        if (!Physics.CheckSphere(dimangiSpawnPoint, spawnCollisionCheckRadius))
        {
            Instantiate(collectable, dimangiSpawnPoint, transform.rotation);
            gems++;
        }    
    }

    IEnumerator CollectableCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(2f);
            SpawnDimangi();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
