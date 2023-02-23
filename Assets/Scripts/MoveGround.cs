using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float moveSpeed;
    public GameControllerScript gc;
    public float ultimateSpeed = 1f;

    void Start()
    {
        moveSpeed = moveSpeed * -1f * ultimateSpeed;
    }

 
    // Update is called once per frame
    void Update()
    {
        ultimateSpeed = gc.ultimateSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * ultimateSpeed);

        if (transform.position.x > 20)
        {
            transform.localPosition = new Vector3(-220f, 0f, 0f);
        }

    }
}

