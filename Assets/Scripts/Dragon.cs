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
        //GetComponent = Atanan de�erin rigidbody2d �zelli�ini _rb'ye atar
        _rb = GetComponent<Rigidbody2D>();
        //_rb.gravityScale = 0; yer�ekimini 0 lar�z nesne havada as�l� kal�r
        _rb.velocity = new Vector2(_rb.velocity.x, 9f); //x i de�i�tirmedik y yi de�i�tirdik

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //sol tu� 0,  mobil cihazlarda ise dokunma
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed); //x i de�i�tirmedik y yi de�i�tirdik
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
