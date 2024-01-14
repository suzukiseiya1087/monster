using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbody2D;

    private float jumpForce = 550f;
    private int maxJumpCount = 5;
    private int jumpCount = 0;
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if W key is pressed and player has not exceeded the jump count
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.jumpCount < maxJumpCount)
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
