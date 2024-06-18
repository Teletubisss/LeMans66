
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector3 _scale;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            body.transform.position = new Vector2(-6, 0);
            HidePlayer();
        }
        else if (collision.tag == "Wall")
        {
            //body.velocity = new Vector2(0, -1 * body.velocity.y);
            body.velocity = new Vector2(0, 0);
        }
    }

    private void HandleUserInputs()
    {
        if (Input.GetKey(KeyCode.Space))
            ShowPlayer();
        
        else if (Input.GetKey(KeyCode.UpArrow))
            body.velocity = new Vector2(0, speed);


        else if (Input.GetKey(KeyCode.DownArrow))
            body.velocity = new Vector2(0, -1 * speed);

        //else
          //  body.velocity = new Vector2(0, 0);
    }

    private void ShowPlayer()
    {
        gameObject.transform.localScale = _scale;
    }

    private void HidePlayer()
    {
        _scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
