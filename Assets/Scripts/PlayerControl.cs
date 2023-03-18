using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float horizontalMove;
    public float speed;

    Rigidbody2D myBody;

    bool grounded = false;

    public float castDist = 0.2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    public float jumpLimit = 2f;

    bool jump1 = false;
    bool jump2 = false;
    bool canDoubleJump = false;

    public bool canShoot = false;

    public GameObject leftBullet;
    public GameObject rightBullet;

    Animator myAnim;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalMove);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump1 = true;
            myAnim.SetBool("jumping", true);
        } else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            jump2 = true;
            canDoubleJump = false;
            myAnim.SetBool("jumping", true);
        }

        if (horizontalMove > 0.2f || horizontalMove < -0.2f)
        {
            myAnim.SetBool("walking", true);
        } else
        {
            myAnim.SetBool("walking", false);
        }

        if (canShoot)
        {
            //Debug.Log(bullet.activeSelf);
            if (Input.GetKeyDown(KeyCode.J))
            {
                canShoot = false;
                Instantiate(leftBullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                canShoot = false;
                Instantiate(rightBullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
        }
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump1)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump1 = false;
            canDoubleJump = true;
        }
        if (jump2)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump2 = false;
        }

        if (myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;

        } else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
            if (grounded)
            {
                myAnim.SetBool("jumping", false);
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down,Color.red);

        if (hit.collider != null && hit.transform.CompareTag("ground"))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            canShoot = true;
        }

        if (collision.gameObject.name == "NextLevel")
        {
            gameManager.GetComponent<GameManager>().nextScene = true;
        }
    }
}
