using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    public Rigidbody2D rigidbody;
    public Rigidbody2D paddle;
    private float _speed = 5.0f;
    private bool _isShoot = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (_isShoot == true)
        {
            Vector3 pos = rigidbody.position;
            Vector3 movePos = pos + transform.up * _speed * Time.deltaTime;
            rigidbody.MovePosition(movePos);
        }
        else
        {
            rigidbody.transform.position = paddle.transform.position + new Vector3(0, 0.13f, 0);
            if (Input.GetMouseButtonUp(0))
                _isShoot = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.collider.transform.position
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_RADIAN - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Meteor"))    // 미완성
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
            // 벽돌 부숴지는 코드
        }
    }
}
