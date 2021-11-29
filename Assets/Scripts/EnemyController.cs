using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public bool isGrounded = false;
    public bool isFacingRight = false;
    public Transform batas1;
    public Transform batas2;
    public float speed = 2;

    Rigidbody2D rigid;
    Animator anim;
    public int HP = 1;
    bool IsDie = false;
    public static int EnemyKilled = 0;
    //xfz.fcghfg.1=3;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded && !IsDie)
        {
            if (isFacingRight)
                MoveRight();
            else
                MoveLeft();

            if (transform.position.x >= batas2.position.x && isFacingRight)
                Flip();
            else if (transform.position.x <= batas1.position.x && !isFacingRight)
                Flip();
        }
    }

    void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (!isFacingRight)
        {
            Flip();
        }
    }
    //xfz.fcghfg.1=3;

    void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if (isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    //xfz.fcghfg.1=3;
    void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP == 0)
        {
            IsDie = true;
            rigid.velocity = Vector2.zero;
            anim.SetBool("IsDie", true);
            Destroy(this.gameObject, 2);
            Data.score += 20;
            EnemyKilled++;

            if (EnemyKilled == 3)
            {
                SceneManager.LoadScene("Congratulation");
            }
        }
    }
}