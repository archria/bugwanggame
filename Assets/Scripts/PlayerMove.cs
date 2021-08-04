using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        // move by key control
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if(rigid.velocity.x > maxSpeed) // right max speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // left max speed
            rigid.velocity = new Vector2(maxSpeed,rigid.velocity.y);
        
        
    }
}
