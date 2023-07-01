using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    // _ means It's private
    private Rigidbody2D _rb;
    //public float speed;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -40;
    public Score score;
    bool touchedGround = false; //Yere deðil deðmediðini kontrol etmemiz gerekiyor
    public GameManager gameManager;
    public Sprite dragonDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource fly, hit, point;
  
    void Start()
    {
        //GetComponent = Atanan deðerin rigidbody2d özelliðini _rb'ye atar
        _rb = GetComponent<Rigidbody2D>();
        //_rb.gravityScale = 0; yerçekimini 0 larýz nesne havada asýlý kalýr
        //_rb.velocity = new Vector2(_rb.velocity.x, 7f); //x i deðiþtirmedik y yi deðiþtirdik
        _rb.gravityScale = 0;

        sp =GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DragonFly();
    }

    void FixedUpdate()
    {
        DragonRotation();
    }

    void DragonFly()
    {
      
       
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver==false) //sol tuþ 0,  mobil cihazlarda ise dokunma
        {
            fly.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 5f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero; // her bastýðýmýzda eþ düzeyde zýplasýn diye 
                _rb.velocity = new Vector2(_rb.velocity.x, _speed); //x i deðiþtirmedik y yi deðiþtirdik

            }


        }
    }

    void DragonRotation()
    {

        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }

        }
        else if (_rb.velocity.y <= -2.5f)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if(touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); //  ? 
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if ((collision.CompareTag("Column") || collision.CompareTag("Fireball")) && GameManager.gameOver == false)
        {
 
            gameManager.GameOver();
            GameOver();
            FishDieEffect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //çarpýþma kontrol edeceðim zaman Oncollision
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
                FishDieEffect();
            }

        }
        
    }

    void FishDieEffect()
    {
        hit.Play(); 
    }

    void GameOver()
    {
        touchedGround = true;
        sp.sprite = dragonDied; //Game Over olunca ejderhanýn spriteýnýn deðiþmesi lazým fakat animasyon devam ederken sprite deðiþtiremeyiz.
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -180); ;
    }
}
