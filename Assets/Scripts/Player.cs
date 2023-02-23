using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public bool isGrounded = false;
    public GameControllerScript gc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // return boolean "true" if layer mask called "ground" is on .1f radius from the position of shpere called "groundCheck".
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
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
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(transform.up * jumpForce);
            }

        // rajoittaa hahmon liikkeen tien reunoihin
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 3f), // x askeli suluissa
            transform.position.y, // y-akseli nolla
            Mathf.Clamp(transform.position.z, -3.3f, 3.3f)); // z-akseli nolla
    }
}
