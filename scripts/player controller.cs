using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool facingR = true;

    private bool isGround;
    private bool isArm;
    public Transform feetPos;
    public Transform armPos;
    public float checkR;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingR == false && moveInput > 0){
            flip();
        }
        else if(facingR == true && moveInput < 0){
            flip();
        }
        if(moveInput == 0){
            anim.SetBool("isRunning", false);
        }
        else{
            anim.SetBool("isRunning", true);
        }
    }

    private void Update(){
        isGround = Physics2D.OverlapCircle(feetPos.position, checkR, whatIsGround);
        isArm = Physics2D.OverlapCircle(armPos.position, checkR, whatIsGround);

        if(isGround == true && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("take off");
        }
        if(isGround == true){
            anim.SetBool("isJumping", false);
        }

        else{
            anim.SetBool("isJumping", true);
        }

        if(isArm == true && moveInput != 0){
            anim.SetBool("isPushing", true);
        }
        else{
            anim.SetBool("isPushing", false);
        }



    }
    void flip(){
        facingR = !facingR;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
