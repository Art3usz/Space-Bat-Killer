using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2();
    private Rigidbody2D rgb2d;
    private void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        rgb2d.velocity = speed;
    }

    public void switchSpeed(float x, float y)
    {
        rgb2d.velocity = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                {
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                }
            case "Nietoperek":
                {
                    PlayerStatsController.PSC.score += 5;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                }
            case "Boss":
                {
                    // tTo do add instruction
                    break;
                }
        }
    }
}
