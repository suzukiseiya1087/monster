using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbody2D;

    private float jumpForce = 350f;

    private int jumpCount = 0;
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)&&this.jumpCount <2)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }
}
