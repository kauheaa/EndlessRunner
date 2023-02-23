using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private bool collected = false;
    public GameControllerScript gc;
    public GameObject gemExplosion;

    public void AddScore()
    {
        gc.scoreUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            if (!collected)
            {
                collected = true;
                AddScore();
                Destroy(other.gameObject);
                GameObject Explosion = Instantiate(gemExplosion, transform.position, transform.rotation);
                Debug.Log("Gem collected");
                Destroy(Explosion, 1);
                collected = false;
            }
        }
    }

    void Update()
    {

    }
}
