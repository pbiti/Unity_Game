using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationsStateController : MonoBehaviour
{   

    public papyrusScript1 state;
    public List<string> items;
    Animator animator;
    int isRunningHash;
    // Start is called before the first frame update
    private bool facingRight;
    void Start()
    {   
        items = new List<string>();
        facingRight = true;
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()
    { 
        float horizontal = Input.GetAxis("Horizontal");
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow));
        bool attackPressed = Input.GetKey(KeyCode.Space);
        bool jumping = Input.GetKey(KeyCode.UpArrow);

        if((Input.GetKey(KeyCode.LeftArrow) && facingRight)){ 
            Flip(horizontal);
        }
        if((Input.GetKey(KeyCode.RightArrow) && !facingRight)){
            Flip(horizontal);
        }

        if(!isRunning && forwardPressed){
            animator.SetBool(isRunningHash, true);
        }
        if(isRunning && !forwardPressed){
            animator.SetBool(isRunningHash, false);
        }
        //RUN
        if(forwardPressed && jumping){
            animator.SetBool("isJumpingRun", true);
        }
        if(!jumping && forwardPressed){
            animator.SetBool("isJumpingRun", false);
        }
        //IDLE
        if(!forwardPressed && jumping){
            animator.SetBool("isJumpingIdle", true);
        }
        if(!jumping && !forwardPressed){
            animator.SetBool("isJumpingIdle", false);
        }
        //ATTACK
        if(attackPressed){
            animator.SetBool("isAttacking", true);
            
        }
        else{animator.SetBool("isAttacking", false);}
    }

    private void Flip(float horizontal){
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

     private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("collectable")){
            string itemtype = collision.gameObject.GetComponent<collectableScript>().itemType;
    		Destroy(collision.gameObject);
    		state = FindObjectOfType<papyrusScript1>();
            if(itemtype == "pap1"){
                state.PausePap(0);
            }
            if(itemtype == "pap2"){
                state.PausePap(1);
            }
            if(itemtype == "pap3"){
                state.PausePap(2);
            }
            if(itemtype == "pap4"){
                state.PausePap(3);
            }
    	}
    	if(collision.CompareTag("CanEnter")){
    		SceneManager.LoadScene("Hidden_Objects");
    	}
    }
}
