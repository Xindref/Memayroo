using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagnolModifier;

    private Animator anim;
    private Rigidbody myRigidbody;

    private bool playerMoving;
    public Vector3 lastMove;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    private bool changing;
    private float changeTimeCounter;
    private float changeTime = .5f;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        playerMoving = false;

        if (!attacking && !changing)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);
                playerMoving = true;
                lastMove = new Vector3(Input.GetAxisRaw("Horizontal"),0f, 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector3(0f, 0f, myRigidbody.velocity.z);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
            }

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5 && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5)
            {
                currentMoveSpeed = moveSpeed * diagnolModifier;
            }
            else {
                currentMoveSpeed = moveSpeed;
            }

        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);

        }

        if (changeTimeCounter > 0)
        {
            changeTimeCounter -= Time.deltaTime;
        }

        if (changeTimeCounter <= 0)
        {
            changing = false;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.z);
    }

    public void Attack()
    {
        attackTimeCounter = attackTime;
        attacking = true;
        myRigidbody.velocity = Vector3.zero;
        anim.SetBool("Attack", true);
    }

    public void ChangeLevel()
    {
        changeTimeCounter = changeTime;
        changing = true;
        myRigidbody.velocity = Vector3.zero;
        lastMove = new Vector3(0, 0, -1);
    }

}