using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float playerMoveSpeed = 10f;
    [SerializeField] private float jumpPower = 10f;

    private Animator anim;
    private float playerMoveX;
    private Rigidbody2D body;
    private bool isGrounded = true;
    private bool isDead = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        // pergerakkan player di x-axis
        playerMoveX = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(playerMoveX * playerMoveSpeed, body.velocity.y);
        PlayerJump();
        SetAnimation();
    }

    private void SetAnimation()
    {
        // 
        if (playerMoveX > 0)
        {
            anim.SetBool("isWalk", true);
            transform.localScale = new Vector3(1f, 1f, 1);
        }

        else if (playerMoveX < 0)
        {
            anim.SetBool("isWalk", true);
            transform.localScale = new Vector3(-1f, 1f, 1);

        }

        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // jika apakah player berada di tanah atau tidak
        // jika tidak maka dia sedang loncat
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Pit" || col.tag == "Enemy")
        {
            // player mati dan semua pergerakkan didisabled
            isDead = true;
            anim.SetBool("isDead", isDead);
            this.enabled = false;

            // player stay di tempat jika mati
        }
    }

    private void PlayerJump()
    {
        // player lompat dengan tekan tombol spasi dan berada pada tanah
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            isGrounded = false;
        }
    }
}
