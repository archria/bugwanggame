using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Think();

        Invoke("Think",5);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        //Move
        rigid.velocity = new Vector2(nextMove,rigid.velocity.y);
        
        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if(rayHit.collider == null){
                Turn();
            }
    }

    void Think(){
        //set next active
        nextMove = Random.Range(-1,2);

        //sprite animation
        anim.SetInteger("WalkSpeed",nextMove);

        //flip sprite
        if(nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;
        
        //recursive
        float nextThinkTime = Random.Range(2f,5f);
        Invoke("Think",nextThinkTime);
        
    }

    void Turn(){
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke(); // cancel time counting
        Invoke("Think", 5); // recount time
    }

    // Update is called once per frame
    void Update() {
        
    }
}
