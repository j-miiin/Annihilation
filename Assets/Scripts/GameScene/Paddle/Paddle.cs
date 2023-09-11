using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D paddle;

    private float _rotationX;
    private float _speed = 3.0f;
    
    public KeyCode Left;
    public KeyCode Right;

    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rotationX = 0f;
        if (Input.GetKey(Left)) { _rotationX -= 1f; }
        if (Input.GetKey(Right)) { _rotationX += 1f; }
        paddle.velocity = new Vector3(_rotationX * _speed, 0, 0);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)      // 패들에 닿을때마다 무작위 각도 발사
    {
        if (collision.collider.CompareTag("Item"))
        {
            
        }
    }
 
    /*
     * private void OnCollisionEnter2D(Collision2D collision)      // 한번 발사된 각도로 무한 고정됨
    {
        if(collision.collider.CompareTag("Ball"))
        {
            if (isShoot == false)
            {
                Vector3 tmp = collision.transform.eulerAngles;
                int r = Random.Range(0, shootAngles.Length);
                tmp.z = shootAngles[r];
                collision.transform.eulerAngles = tmp;
                isShoot = true;
            }
            else
            {
                Vector3 tmp = collision.transform.eulerAngles;
                tmp.z = C_RADIAN - tmp.z;
                collision.transform.eulerAngles = tmp;
            }
        }
        // if (collision.tag == "Item")
    }
    */
}
