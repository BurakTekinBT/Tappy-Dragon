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
    int maxAngle = 25;
    int minAngle = -20;
    public Score score;
  
    void Start()
    {
        //GetComponent = Atanan deðerin rigidbody2d özelliðini _rb'ye atar
        _rb = GetComponent<Rigidbody2D>();
        //_rb.gravityScale = 0; yerçekimini 0 larýz nesne havada asýlý kalýr
        _rb.velocity = new Vector2(_rb.velocity.x, 7f); //x i deðiþtirmedik y yi deðiþtirdik

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
        _rb.velocity = Vector2.zero; // her bastýðýmýzda eþ düzeyde zýplasýn diye 
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false) //sol tuþ 0,  mobil cihazlarda ise dokunma
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed); //x i deðiþtirmedik y yi deðiþtirdik
        }
    }

    void DragonRotation()
    {

        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 3;
            }

        }
        else if (_rb.velocity.y <= 0)
        {
            if (angle > minAngle)
            {
                angle = angle - 1;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            //game over
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //çarpýþma kontrol edeceðim zaman Oncollision
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Dragon Died!");
            //game over
            if(GameManager.gameOver == false)
            {
                //game over
            }
            else
            {
                //gmae over
            }
        }
        
    }
}
