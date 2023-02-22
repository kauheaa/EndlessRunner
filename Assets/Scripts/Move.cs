using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Material roadMaterial;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("heelloo");
        roadMaterial = GetComponent<Renderer>().material;
        speed = speed * -1;
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Time.time * speed;
        roadMaterial.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }
}
