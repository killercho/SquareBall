using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeColor : MonoBehaviour
{
    public GameObject Ball;
    private BallScript BallScript;

    public Tilemap BlueField;
    public Tilemap YellowField;
    private TileBase greenTile;
    private TileBase redTile;

    private int ballBlueLives;
    private int ballYellowLives;

    private void Start()
    {
        BallScript = Ball.GetComponent<BallScript>();

        greenTile = Resources.Load("GreenSquare") as TileBase;
        redTile = Resources.Load("RedSquare") as TileBase;
    }

    private void Update()
    {
        ballBlueLives = BallScript.GetBlueLives();
        ballYellowLives = BallScript.GetYellowLives();

        ChangeColorFunction();
    }

    public void ChangeColorFunction()
    {
        if (ballYellowLives == 1)
        {
            for (int i = 0; i <= 8; i++)
            {
                YellowField.SetTile(new Vector3Int(i, -4, 0), redTile);
            }
        }
        else
        {
            for (int i = 0; i <= 8; i++)
            {
                YellowField.SetTile(new Vector3Int(i, -4, 0), greenTile);
            }
        }

        if (ballBlueLives == 1)
        {
            for (int i = -10; i < -1; i++)
            {
                BlueField.SetTile(new Vector3Int(i, -4, 0), redTile);
            }
        }
        else
        {
            for (int i = -10; i < -1; i++)
            {
                BlueField.SetTile(new Vector3Int(i, -4, 0), greenTile);
            }
        }
    }
}
