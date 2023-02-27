using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
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
                GameObject explosion = Instantiate(gemExplosion, transform.position, transform.rotation);
                Debug.Log("Gem collected");
                Destroy(explosion, 1);
                collected = false;
            }
        }
    }

}
