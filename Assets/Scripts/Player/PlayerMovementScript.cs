using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementScript : MonoBehaviour
{
   
    public Vector2 speed;
    private Rigidbody2D rgb2d;
    private void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        Vector2 movement = new Vector2();
        if (Input.GetKey(GameManager.GM.down))
        {
            movement.y = -speed.y;
        }

        if (Input.GetKey(GameManager.GM.up))
        {
            movement.y = this.speed.y;
        }

        if (Input.GetKey(GameManager.GM.left))
        {
            movement.x = -this.speed.x;
        }

        if (Input.GetKey(GameManager.GM.right))
        {
            movement.x = this.speed.x;
        }

        rgb2d.velocity = movement;
    }
}
