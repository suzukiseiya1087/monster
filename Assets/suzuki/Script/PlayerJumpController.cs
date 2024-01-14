using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbody2D;
    private float jumpForce = 550f;
    private int jumpCount = 0;
    private int maxJumpCount = 2; // Maximum number of jumps before needing to touch the ground

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if W key is pressed and player has not exceeded the jump count
        if (Input.GetKeyDown(KeyCode.W) && this.jumpCount < maxJumpCount)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            // Reset jump count when player touches the floor
            jumpCount = 0;
        }
    }
}

