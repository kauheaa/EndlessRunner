using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCollectable : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
    }
}
