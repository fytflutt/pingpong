using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Vector2 Dir;
    public float Force;
    public Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Dir = new Vector3 (Random.Range(1, -1), Random.Range(1, -1));
        Rb.AddForce(Dir.normalized * Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
