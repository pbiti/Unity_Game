using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotaurControl : MonoBehaviour
{
    private enum State {
        Walking, 
        Knockback,
        Dead
    }

    [SerializeField]
    private float
        groundCheckDistance, wallCheckDistance, movementSpeed, maxHealth, knockbackDuration; 
    [SerializeField]
    private Transform
        groundCheck, wallCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Vector2 knockbackSpeed;
    private float currentHealth, knockbackStartTime;
    private int facingDirection, damageDirection;
    private Vector2 movement;
    private GameObject alive;
    private Rigidbody2D aliveRb;
    private Animator aliveAnim;
    private State currentState;
    private bool groundDetected, wallDetected;
    public GameObject showDoor;

    private void Start(){
        alive = gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();
        
        currentHealth = maxHealth;
        facingDirection = 1;
    }
    private void Update(){
        switch(currentState){
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    //--WALKING STATE

    private void EnterWalkingState(){}

    private void UpdateWalkingState(){
        //groundDetected = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(wallDetected){
            //FLIP ENEMY
            Flip();
        }else{
            //MOVE
            movement.Set(movementSpeed*facingDirection, aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }

    private void ExitWalkingState(){
        
    }

    IEnumerator test_hit(){
        aliveAnim.Play("Get_Hit");
        movementSpeed = 0;
        yield return new WaitForSeconds(1);
    }

    //--KNOCKBACK STATE
    private void EnterKnockbackState(){
        knockbackStartTime = Time.time;
        //movement.Set(knockbackSpeed.x*damageDirection, knockbackSpeed.y);
       if(damageDirection == -1){Flip();}
        aliveRb.velocity = movement;
        //aliveAnim.SetBool("Knockback", true);
        //aliveAnim.Play("Idle");
        StartCoroutine(test_hit());
        movementSpeed=1;
    }

    private void UpdateKnockbackState(){
        if(Time.time >= knockbackStartTime + knockbackDuration){
            SwitchState(State.Walking);
        }
    }

    private void ExitKnockbackState(){
        aliveAnim.SetBool("Knockback", false);
    }

    IEnumerator test_death(){
        if(damageDirection == -1){Flip();}
        aliveAnim.Play("Death2");
        movementSpeed = 0;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        showDoor.SetActive(true);
    }

    //--DEAD STATE
    private void EnterDeadState(){
        //Spawn chuncks and blood
        StartCoroutine(test_death());    
    }

    private void UpdateDeadState(){

    }

    private void ExitDeadState(){
        
    }

    //--OTHER FUNCTIONS
    public void Damage(float[] attackDetails){
        currentHealth -= attackDetails[0];
        
        if(attackDetails[1] > alive.transform.position.x && facingDirection==1){
            damageDirection = 1;
            print("HIT FROM BEHIND");
        }else if(attackDetails[1] > alive.transform.position.x && facingDirection==-1){
            damageDirection = -1;
            print("HIT FROM THE FRONT");
        }else if(attackDetails[1] < alive.transform.position.x && facingDirection==1){
            damageDirection = -1;
        }else if(attackDetails[1] < alive.transform.position.x && facingDirection==-1){
            damageDirection = 1;
        }

        //HIT PARTICLE

        if(currentHealth > 0.0f){
            SwitchState(State.Knockback);
        }else if(currentHealth <= 0.0f){
            SwitchState(State.Dead);
        }
    }
    private void Flip(){
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void SwitchState(State state){
        switch(currentState){
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch(state){
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;
    }

    private void OnDrawnGizmos(){
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
}
