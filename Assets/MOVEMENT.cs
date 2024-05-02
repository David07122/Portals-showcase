using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENT : MonoBehaviour
{
  
        public float moveSpeed = 5f; // Speed of player movement
        public float jumpForce = 10f; // Force applied when jumping
        public KeyCode moveLeftKey = KeyCode.A; // Key for moving left
        public KeyCode moveRightKey = KeyCode.D; // Key for moving right
        public KeyCode jumpKey = KeyCode.Space; // Key for jumping
        private bool isGrounded; // To check if the player is on the ground

        // Update is called once per frame
        void Update()
        {
            // Movement input
            float horizontalInput = 0f;
            if (Input.GetKey(moveLeftKey))
            {
                horizontalInput = -1f;
            }
            else if (Input.GetKey(moveRightKey))
            {
                horizontalInput = 1f;
            }

            // Apply movement
            Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);
            transform.position += movement;

            // Jump input
            if (Input.GetKeyDown(jumpKey) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
                isGrounded = false;
            }
        }

        // Check if the player is on the ground
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }

        }
    }

