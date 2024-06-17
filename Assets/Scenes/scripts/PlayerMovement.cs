
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float speed; 


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, 0);
        body.transform.position = new Vector2(-6, 0);
    }

    private void Update()
    {
        HandleUserInputs();
        //OnTriggerEnter2D();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            body.transform.position = new Vector2(-6, 0);
            gameObject.SetActive(false);
        }
    }

    private void HandleUserInputs()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            body.velocity = new Vector2(0, speed);

        else if (Input.GetKey(KeyCode.DownArrow))
            body.velocity = new Vector2(0, -1 * speed);

        else
            body.velocity = new Vector2(0, 0);
    }
}
