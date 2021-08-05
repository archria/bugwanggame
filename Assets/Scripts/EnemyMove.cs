using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        rigid.velocity = new Vector2(-1,rigid.velocity.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
