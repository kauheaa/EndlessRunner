using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject playerExplosion;
    public float moveSpeed = 1f;
    public float ultimateSpeed = 1f;
    private float[] offset = new float[3] {-3.3f, 0f, 3.3f};
    private bool playerDead;
    public GameControllerScript gc;

    void Start()
    {
        moveSpeed = moveSpeed * -1 * ultimateSpeed;
    }

IEnumerator GameOver()
{
    yield return new WaitForSeconds(1);
    gc.GameOver();
    Debug.Log("Game Over");
    }

void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!playerDead)
            {
            playerDead = true;
            other.gameObject.SetActive(false);
            GameObject explosion = Instantiate(playerExplosion, transform.position, transform.rotation);
            Debug.Log("Dead");
            Destroy(explosion, 1);
            StartCoroutine(GameOver());
            playerDead = false;
            }

        }
    }
 
    // Update is called once per frame
    void Update()
    {
        ultimateSpeed = gc.ultimateSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * ultimateSpeed);

        if (transform.position.x > 15)
        {
            int randomIndex = Random.Range(0, 3);
            float newZPosition = offset[randomIndex];
            transform.position = new Vector3(-220f, 0f, newZPosition);
        }

    }
}

