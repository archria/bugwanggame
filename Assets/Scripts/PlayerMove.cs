using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Start() {
        Debug.Log("start");        
    }

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //Stop speed
        if(Input.GetButtonUp("Horizontal")) // up = 떼는거
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.2f , rigid.velocity.y);
        //directon sprite
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // 왼쪽일때 flip x
        
        //Animation
        if(Mathf.Abs( rigid.velocity.x ) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        // move by key control
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // accelerator
        //rigid.velocity = new Vector2(maxSpeed*h, rigid.velocity.y); // fixed velocity
        if(rigid.velocity.x > maxSpeed) // right max speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // left max speed
            rigid.velocity = new Vector2(maxSpeed * (-1) ,rigid.velocity.y);

    }
}
