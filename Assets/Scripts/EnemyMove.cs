using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        Think();

        Invoke("Think",5);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        rigid.velocity = new Vector2(nextMove,rigid.velocity.y);
    }

    void Think(){
        nextMove = Random.Range(-1,2);

        Invoke("Think",5);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
