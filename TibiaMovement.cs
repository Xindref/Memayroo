using UnityEngine;
using System.Collections;

public class TibiaMovement : MonoBehaviour
{

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

        if (!attacking)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);
                playerMoving = true;
                lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
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
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector3.zero;
                anim.SetBool("Attack", true);
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

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.z);
    }

}