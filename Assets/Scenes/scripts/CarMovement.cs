
using UnityEngine;

public class CarMovement : MonoBehaviour

{
    [SerializeField] private float Car2speed;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.transform.position = new Vector2(12, Random.Range(-3.5f, 3.5f));
    }

    private void Update()
    {
        body.velocity = new Vector2(-1 * Car2speed, 0);
        if (body.transform.position.x < -12)
        {
            body.transform.position = new Vector2(12, Random.Range(-3.5f, 3.5F));
        }

        //if (collision.tag == "Player")
        //    body.transform.position = new Vector2(12, Random.Range(-3.5f, 3.5f));
    }
}
