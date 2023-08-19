using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLevelObjects : MonoBehaviour
{
    public Vector3 CowPos;

    void Start()
    {
        CowPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    public void ResetCows()
    {
        {
            {
                gameObject.transform.position = CowPos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
