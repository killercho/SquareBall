using UnityEngine;

public class Player2 : MonoBehaviour
{
    AudioSource audioData;
    public Rigidbody2D rb;

    public float speed = 4500f;
    public float jumpForce = 250f;
    int MAX_JUMP_TIMEOUT = 70;
    int jumpTimeout = 30;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        //Store the current input
        float movementOnGround = Input.GetAxis("P2_horizontal");
        float movementVertical = Input.GetAxis("P2_vertical");

        Vector2 movement = new Vector2(movementOnGround, 0);

        if (jumpTimeout > 0) jumpTimeout--;

        if (movementVertical >= 0.1 && jumpTimeout <= 0)
        {
            audioData.Play(0);
            jumpTimeout = MAX_JUMP_TIMEOUT;
            rb.velocity = new Vector2(rb.velocity.x, (Vector2.up * jumpForce * Time.deltaTime).y);
        }

        rb.AddForce(movement * speed * Time.deltaTime);
    }
}
