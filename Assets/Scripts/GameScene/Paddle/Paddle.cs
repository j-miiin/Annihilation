using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public GameObject item;
    public Rigidbody2D paddleRb;
    public Rigidbody2D ballRb;

    private float _rotationX;
    private float _paddlespeed = 5.0f;
    private float _ballspeed = 4.0f;
    
    public KeyCode Left;
    public KeyCode Right;

    void Start()
    {
        paddleRb = GetComponent<Rigidbody2D>();
        ballRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rotationX = 0f;
        if (Input.GetKey(Left)) { _rotationX -= 1f; }
        if (Input.GetKey(Right)) { _rotationX += 1f; }
        paddleRb.velocity = new Vector3(_rotationX * _paddlespeed, 0, 0);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)      // �е鿡 ���������� ������ ���� �߻�
    {
        if (collision.CompareTag("Item"))
        {
            // ItemManager.instance.GetItem();
        }
    }
 
    
    /*
     * private void OnCollisionEnter2D(Collision2D collision)      // �ѹ� �߻�� ������ ���� ������
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
