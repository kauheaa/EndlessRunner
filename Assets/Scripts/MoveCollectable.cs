using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCollectable : MonoBehaviour
{
    public GameControllerScript gc;
    public float moveSpeed = 1f;
    public float ultimateSpeed = 1f;
    GameObject gameController;

    void Start(){
        moveSpeed = moveSpeed * ultimateSpeed;
        gameController = FindObjectOfType<GameControllerScript>().gameObject;
        gc = gameController.GetComponent<GameControllerScript>();
    }
    void Update()
    {
        ultimateSpeed = gc.ultimateSpeed;
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * ultimateSpeed);
        
        if (transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
    }
}
