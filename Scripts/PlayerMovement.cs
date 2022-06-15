 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveInput;
    public Rigidbody2D rb;
    public float speed;
    public Transform pos;
    public float radius;
    public LayerMask groundLayers;
    public float jumpForce;
    public float heightCutter;
    bool grounded;
    public bool canDoubleJump;
    //int jumpcount = 0;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        grounded = Physics2D.OverlapCircle(pos.position, radius, groundLayers);

        if(Input.GetKeyDown(KeyCode.UpArrow)){
        	soundmanagerscript.PlaySound("jump");
            if(grounded) {
                rb.velocity = Vector2.up * jumpForce;
                canDoubleJump = true;
            }else{
                if(canDoubleJump){
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce / 1.75f);
                }
            }
            
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)){
            if(rb.velocity.y > 0){
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * heightCutter);
            }
        }
    }
}
