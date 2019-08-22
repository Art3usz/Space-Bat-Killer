using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovementScript : MonoBehaviour
{
    public Vector2 speed;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = speed;
    }
}
