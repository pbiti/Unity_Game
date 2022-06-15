using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private Transform attackHitBoxPos;
    [SerializeField]
    private float attackRadius, attackDamage;
    [SerializeField]
    private LayerMask whatIsDamageable;

    private float[] attackDetails = new float[2];

    private GameObject alive;
    private Rigidbody2D aliveRb;
    private Animator anim;


    private void Start(){
       // alive = transform.Find("Idle").gameObject;
        aliveRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void CheckAttackHitBox(){
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBoxPos.position, attackRadius, whatIsDamageable);

        attackDetails[0] = attackDamage;
        attackDetails[1] = transform.position.x;

        foreach (Collider2D collider in detectedObjects){
            collider.transform.parent.SendMessage("Damage", attackDetails);           
        }
    }

    IEnumerator test(){
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }

    public void OnCollisionEnter2D(Collision2D collision){
         
         if(collision.gameObject.transform.parent.name == "Alive" || collision.gameObject.tag == "Trap" || collision.gameObject.transform.name == "Alive"){
            //print("incollision");
            anim.Play("Death", 0, 0.25f);
            StartCoroutine(test());
             // Application.LoadLevel(Application.loadedLevel);
             //Destroy(gameObject);
         }
     }
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(attackHitBoxPos.position, attackRadius);
    }
}
