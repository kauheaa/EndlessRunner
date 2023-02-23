using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameControllerScript gc;
    public GameObject collectable;
    private float[] zOffset = new float[3] { -3.3f, 0f, 3.3f };
    private float[] yOffset = new float[2] { 0.5f, 2.5f };
    private float spawnCollisionCheckRadius = 3;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnDimangi();
        StartCoroutine(CollectableCoroutine());
    }

    public void SetSpawnPoint()
    {
        int randomHorizontal = Random.Range(0, 3);
        int randomVertical = Random.Range(0, 2);
        float newZPosition = zOffset[randomHorizontal];
        float newYPosition = yOffset[randomVertical];
        spawnPoint = new Vector3(-100f, newYPosition, newZPosition);
    }

    public void SpawnDimangi()
    {
        SetSpawnPoint();
        if (!Physics.CheckSphere(spawnPoint, spawnCollisionCheckRadius))
        {
            Instantiate(collectable, spawnPoint, transform.rotation);
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
