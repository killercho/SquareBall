using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text ScoreBlue;
    public Text ScoreYellow;

    private bool firstSpawn = true;

    private int maxBallLives = 2;
    private int ballBlueLives = 2;
    private int ballYellowLives = 2;

    private int blueDeaths = 0;
    private int yellowDeaths = 0;


    private void Update()
    {
        if (firstSpawn)
        {
            //Get random direction and force when first starting the game.
            float randomForce = Random.Range(25, 65);
            float randomDirection = Mathf.Sign(Random.Range(-1, 1));
            Vector2 directionLauched = new Vector2(randomDirection * randomForce,0);
            rb.AddForce(directionLauched);
            firstSpawn = false;
        }

        CheckBallLives();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "BlueField")
        {
            ballBlueLives--;
            ballYellowLives = maxBallLives; 
        }
        else if (other.gameObject.name == "YellowField")
        {
            ballYellowLives--;
            ballBlueLives = maxBallLives;
        }
    }
    
    private void CheckBallLives()
    {
        if (ballBlueLives == 0)
        {
            blueDeaths++;
            ScoreYellow.text = blueDeaths.ToString();
        }
        if (ballYellowLives == 0)
        {
            yellowDeaths++;
            ScoreBlue.text = yellowDeaths.ToString();
        }
        MoveBallIfDeath();
    }

    private void MoveBallIfDeath()
    {
        if (ballBlueLives == 0 || ballYellowLives == 0)
        {
            float randomDirection = Mathf.Sign(Random.Range(-1, 1));
            float randomForce = Random.Range(25, 65);
            Vector2 directionStart = new Vector2(randomDirection * randomForce, 0);

            rb.velocity = Vector2.zero;
            transform.position = new Vector2(-0.5f, 2.5f);
            rb.AddForce(directionStart);
            ballBlueLives = maxBallLives;
            ballYellowLives = maxBallLives;
        }
    }

    public int GetBlueLives()
    {
        return ballBlueLives;
    }
    public int GetYellowLives()
    {
        return ballYellowLives;
    }
}
