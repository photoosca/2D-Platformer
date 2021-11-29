using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;
    public GameObject Projectile;
    public Vector2 projectileVelocity;
    public float speed = 1f;
    public float jmppwr = 300f;
    private float dashTm;
    public float startDashTM;
    private int Ddirection;


    public Vector2 projectileOffset;
    public float cooldown = 0.5f;
    bool isCanShoot = true; 

    private Rigidbody2D rb;
    public float dashSpd;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTm = startDashTM;
        
        anim = GetComponent<Animator>();
        isCanShoot = false;
        EnemyController.EnemyKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Jump "+isJump);
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Idle();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Idle();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SlideLeft();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SlideRight();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }



        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }
        Move();
        Slide();
        Dead();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Tuch ground
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Tuch ground
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("slide");
        anim.ResetTrigger("idle");
        isJump = true;
    }

    public void MoveRight()
    {
        idMove = 1;
    }

    public void MoveLeft()
    {
        idMove = 2;
    }

    public void SlideLeft()
    {
        Ddirection = 2;
    }

    public void SlideRight()
    {
        Ddirection = 1;
    }


    /*if (dashTm <= 0)
                {
                    Ddirection = 0;
                    dashTm = startDashTM;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTm -= Time.deltaTime;

                    if (Ddirection == 1)
                    {
                        rb.velocity = Vector2.left * dashSpd;
                    }
                    else if (Ddirection == 2)
                    {
                        rb.velocity = Vector2.right * dashSpd;
                    }
                }




    private void Slide()
    {

        if (dashTm <= 0)
        {
            Ddirection = 0;
            dashTm = startDashTM;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTm -= Time.deltaTime;


            if (Ddirection == 2 && !isDead)
            {
               
                if (!isJump) anim.SetTrigger("run");
                rb.velocity = Vector2.right * dashSpd;

                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (Ddirection == 1 && !isDead)
            {
          
                if (!isJump) anim.SetTrigger("run");
                rb.velocity = Vector2.left * dashSpd;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }*/





    private void Move()
    {

            if (idMove == 1 && !isDead)
            {
            // move right con
            if (!isJump) anim.SetTrigger("run");
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);                
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (idMove == 2 && !isDead)
            {
                // move left con
                if (!isJump) anim.SetTrigger("run");
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);                
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        
    }

    public void Jump()
    {
        if (!isJump)
        {
            // jump con
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jmppwr);
        }
    }

    private void Slide()
    {
        if (dashTm <= 0)
        {
            Ddirection = 0;
            dashTm = startDashTM;
            //transform.Translate(0 * Time.deltaTime * speed, 0, 0);
            //rb.velocity = Vector2.zero;
        }
        else
        {
            dashTm -= Time.deltaTime;


            if (Ddirection == 1 && !isDead)
            {
                // R con
                if (!isJump) anim.SetTrigger("slide");
                transform.Translate(1 * Time.deltaTime * dashSpd, 0, 0);
                //rb.velocity = Vector2.right * dashSpd;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (Ddirection == 2 && !isDead)
            {
                // L con
                if (!isJump) anim.SetTrigger("slide");
                transform.Translate(-1 * Time.deltaTime * dashSpd, 0, 0);
                //rb.velocity = Vector2.left * dashSpd;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    /*private void Slide()
    {

        if (dashTm <= 0)
        {
            Ddirection = 0;
            dashTm = startDashTM;
            //rb.velocity = Vector2.zero;
        }
        else
        {
            dashTm -= Time.deltaTime;


            if (Ddirection == 2 && !isDead)
            {
                dashTm = startDashTM;
                
                if (!isJump) anim.SetTrigger("run");
                rb.velocity = Vector2.right * dashSpd;

                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (Ddirection == 1 && !isDead)
            {
                dashTm = startDashTM;
                
                if (!isJump) anim.SetTrigger("run");
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * dashSpd);

                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);

            if (Data.score == 10)
            {
                SceneManager.LoadScene("Congratulation");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Peluru"))
        {
            isCanShoot = true;
        }
        if (collision.transform.tag.Equals("Enemy"))
        {
            SceneManager.LoadScene("Game Over");
            isDead = true;
        }
    }

    public void Idle()
    {

        if (!isJump)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("slide");
            anim.SetTrigger("idle");
        }
        idMove = 0;
    }

    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {

                isDead = true;
            }
        }
    }

    void Fire()
    {

        if (isCanShoot)
        {
            //new proj
            GameObject bullet = Instantiate(Projectile, (Vector2)transform.position - projectileOffset * transform.localScale.x, Quaternion.identity);


            Vector2 velocity = new Vector2(projectileVelocity.x * transform.localScale.x, projectileVelocity.y);
            bullet.GetComponent<Rigidbody2D>().velocity = velocity * -1;


            Vector3 scale = transform.localScale;
            bullet.transform.localScale = scale * -1;

            StartCoroutine(CanShoot());
            anim.SetTrigger("shoot");
        }
    }

    IEnumerator CanShoot()
    {
        anim.SetTrigger("shoot");
        isCanShoot = false;
        yield return new WaitForSeconds(cooldown);
        isCanShoot = true;

    }
}