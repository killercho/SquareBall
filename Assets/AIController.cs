using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject Ball;
    public Rigidbody2D rb;
    private AudioSource audioData;

    private float speed = 800f;
    private float jumpForce = 6f;
    private int MAX_JUMP_TIMEOUT = 1000;
    private int jumpTimeout = 300;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        float ballYPosition = Ball.transform.position.y;
        float ballXPosition = Ball.transform.position.x;

        if (jumpTimeout > 0) jumpTimeout--;

        if (ballXPosition > -0.3)
        {
            if(ballYPosition > -2.4 && jumpTimeout <= 0)
            {
                audioData.Play(0);
                jumpTimeout = MAX_JUMP_TIMEOUT;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            int direction = 0;
            if (ballXPosition < rb.transform.position.x)
                direction = -1;
            else direction = 1;

            Vector2 aiMovement = new Vector2(direction, 0);
            rb.AddForce(aiMovement * speed * Time.deltaTime);
        }
        else
        {
            if(rb.transform.position.x != 6)
            {
                int direction = 0;
                if(rb.transform.position.x < 6)
                    direction = 1;
                else direction = -1;

                Vector2 aiMovement = new Vector2(direction, 0);
                rb.AddForce(aiMovement * speed * Time.deltaTime);
            }
        }

        //Jump higher to move in your field if stuck
        if(rb.transform.position.x < -0.5)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce + 4);
    }
}
