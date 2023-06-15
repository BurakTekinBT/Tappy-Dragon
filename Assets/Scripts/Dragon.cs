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
        _rb.velocity = new Vector2(_rb.velocity.x, 9f); //x i deðiþtirmedik y yi deðiþtirdik

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //sol tuþ 0,  mobil cihazlarda ise dokunma
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed); //x i deðiþtirmedik y yi deðiþtirdik
        }

        if (_rb.velocity.y > 0)
        {
            if(angle <= maxAngle)
            {
                angle += 2;
            }

        }
        else if (_rb.velocity.y <=0)
        {
            if(angle> minAngle)
            {
                angle = angle -1;
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
    }
}
