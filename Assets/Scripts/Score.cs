using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    private bool collected = false;
    public CanvasController canvasController;
    public GameObject gemExplosion;

    public void AddScore()
    {
        canvasController.scoreUpdate();
    }

    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            if (!collected)
            {
                AddScore();
                collected = true;
                Destroy(other.gameObject);
                GameObject Explosion = Instantiate(gemExplosion, transform.position, transform.rotation);
                collected = false;
                Destroy(Explosion, 1);
            }
        }
    }

    void Update()
    {

    }
}
