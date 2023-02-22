using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public Rigidbody rb;
    public bool isGrounded = false;
    public CanvasController canvasController;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            // character moves to direction when key is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpForce);
                isGrounded = false;
            Debug.Log("Not Grounded");
        }

        

        // rajoittaa hahmon liikkeen tien reunoihin
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 3f), // x askeli suluissa
            transform.position.y, // y-akseli nolla
            Mathf.Clamp(transform.position.z, -3.3f, 3.3f)); // z-akseli nolla
    }
}
