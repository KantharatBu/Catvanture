using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public static PlayerMovement instance;
    int coinScore;
    public Text coinText;

    public Vector3 posPlayer;
    public int posPlayerFall;

    public float walkSpeed;
    public float runSpeed;
    public float jumpVelocity;
    public float jumpWaitTime;
    public LayerMask ground;
    public Collider2D foot;
    public ParticleSystem dust;
    public AudioSource jumpVfx;
    public AudioSource CoinSound;
    public AudioSource walkSound;
    public AudioSource catSound;
   
    private bool isGround;
    public bool isPass = false;

    private float jumpWaitTimer;

    public GameObject gameoverCanva, coinCanvas;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        coinCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        isGround = foot.IsTouchingLayers(ground); 

        if (isPass == false)
        {
            Walk();
            Run();
            CreateDust();
            Respawn();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGround || jumpWaitTimer > 0f)
                {
                    Jump();
                }

            }

            //เวลานับ

            if (isGround)
            {
                anim.SetBool("isJump", false);

                jumpWaitTimer = jumpWaitTime;
            }
            else
            {
                anim.SetBool("isJump", true);

                // anim.SetBool("isWalk", false);
                // anim.SetBool("isRunning", false);
                if (jumpWaitTimer > 0f)
                {
                    jumpWaitTimer -= Time.deltaTime;
                }
            }
        }
        
    }
    void Walk()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(walkSpeed * direction * Time.fixedDeltaTime, rb.velocity.y);
       



        if (direction != 0f)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);
            anim.SetBool("isWalk", true);
            //walkSound.Play();
        }
        else
        {
            anim.SetBool("isWalk", false);
           
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            float direction = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(runSpeed * direction * Time.fixedDeltaTime, rb.velocity.y);
           
            anim.SetBool("isWalk", false);
           
            if (direction != 0f)
            {
                anim.SetBool("isRunning", true);
               

            }
            

        }
        else
        {
            anim.SetBool("isRunning", false);
        }



    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
        jumpVfx.Play();
    }

    void CreateDust()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
        {
            dust.Play();
        }
        
    }

    void Respawn()
    {
        
            Vector3 Falling = GetComponent<Transform>().position;
            if (Falling[1] < posPlayerFall)
            {
                if(coinScore > 0)
                {
                    transform.position = (posPlayer);
                    coinScore = coinScore - 1;
                    coinText.text = coinScore.ToString();
                }
                else
                {
                    gameoverCanva.SetActive(true);
                }
                
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "YellowCoin")
        {
            coinScore = coinScore + 1;
            coinText.text = coinScore.ToString();
            CoinSound.Play();
        }

        if (collision.gameObject.tag == "RedCoin")
        {
            coinScore = coinScore + 2;
            coinText.text = coinScore.ToString();
            CoinSound.Play();
        }

        if (collision.gameObject.tag == "Finish")
        {
            isPass = true;
            anim.SetBool("isFinish", true);
            catSound.Play();
        }
    }

}
