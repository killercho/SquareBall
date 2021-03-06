using UnityEngine;

public class Player1 : MonoBehaviour
{
    AudioSource audioData;
    public Rigidbody2D rb;

    public float speed = 7500f;
    public float jumpSpeed = 300f;
    int MAX_JUMP_TIMEOUT = 70;
    int jumpTimeout = 30;

    private void Start() {
        audioData = GetComponent<AudioSource>();    
    }
    private void FixedUpdate()
    {
        //Store the current input
        float movementOnGround = Input.GetAxis("P1_horizontal");
        float movementVertical = Input.GetAxis("P1_vertical");

        Vector2 movement = new Vector2(movementOnGround, 0);

        if (jumpTimeout > 0) jumpTimeout--;

        if (movementVertical >= 0.1 && jumpTimeout <= 0)
        {
            audioData.Play(0);
            jumpTimeout = MAX_JUMP_TIMEOUT;
            rb.velocity = Vector2.up * jumpSpeed * Time.deltaTime;
        }

        rb.AddForce(movement * speed * Time.deltaTime);

    }
}
