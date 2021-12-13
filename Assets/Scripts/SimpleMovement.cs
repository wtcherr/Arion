using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public bool airControl;
    public float gravity=10f;
    public float defaultGravity=-0.2f;
    public float walkSpeed=2f;
    public float runSpeed=2f;
    private float curSpeed=0f;
    public float jumpForce=100f;
    private float jumpPosition;
    [Range(0.1f,1)]
    public float acceleration=0.5f;
    public float airDrag=0.1f;
    private float curAcceleration;
    private bool isGrounded;
    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    public Transform groundCheck;
    public LayerMask ground;
    public float groundRadius=1f;
    private Vector3 velocity;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    void Update() {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        getInput();
        getGravity();
        doMovement();
        setAnimator();
        flip();
    }
    private void getInput(){
        movementDirection.x=Input.GetAxis("Horizontal");
        isJumping=Input.GetKeyDown(KeyCode.Space);
        isRunning=Input.GetKey(KeyCode.LeftShift);
    }
    private void getGravity(){
        isGrounded=Physics2D.OverlapCircle(groundCheck.position,groundRadius,ground);
        if(!isGrounded){
            velocity.y-=gravity*Time.deltaTime;
        }else{
            velocity.y=defaultGravity;
        }
    }
    private void doMovement(){
        if(isGrounded){
            curAcceleration=acceleration;
            if(isRunning){
                curSpeed=runSpeed;
            }else curSpeed=walkSpeed;
        }else{
            if(!airControl){
                curSpeed=0f;
                curAcceleration=airDrag;
            }
        }
        velocity.x=Mathf.Lerp(velocity.x,movementDirection.x*curSpeed,curAcceleration);
        transform.position+=velocity*Time.deltaTime;
        if(isGrounded && isJumping){
            rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        }
    }
    private void setAnimator(){
        anim.SetBool("IsRunning",isRunning);
        anim.SetFloat("Speed",Mathf.Abs(velocity.x));
    }
    private void flip(){
        Vector3 scale=transform.localScale;
        if(movementDirection.x!=0 && (scale.x>0)^(movementDirection.x>0)){
            scale.x*=-1;
            transform.localScale=scale;
        }
    }
}
