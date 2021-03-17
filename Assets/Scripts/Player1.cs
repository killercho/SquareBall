using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player1 : MonoBehaviour
{
    AudioSource audioData;
    public Rigidbody2D rb;

    public float speed = 7500f;
    public float jumpForce = 250f;
    int MAX_JUMP_TIMEOUT = 70;
    int jumpTimeout = 30;

    private void Start() {
        audioData = GetComponent<AudioSource>();    
    }
    private void FixedUpdate()
    {
        //Store the current input
        float movementOnGround = Input.GetAxis("P1_horizontal") + CrossPlatformInputManager.GetAxis("Horizontal");
        float movementVertical = CrossPlatformInputManager.GetAxis("Jump");

        Vector2 movement = new Vector2(movementOnGround, 0);

        if (jumpTimeout > 0) jumpTimeout--;

        if (movementVertical > 0 && jumpTimeout <= 0)
        {
            audioData.Play(0);
            jumpTimeout = MAX_JUMP_TIMEOUT;
            rb.velocity = new Vector2(rb.velocity.x, (Vector2.up * jumpForce * Time.deltaTime).y);
        }

        rb.AddForce(movement * speed * Time.deltaTime);

    }
}
