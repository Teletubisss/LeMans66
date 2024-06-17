
using UnityEngine;

public class CarMovement : MonoBehaviour

{
    [SerializeField] private float Car2speed;

    private Rigidbody2D body;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private GameObject _endGameScreen;
    private bool _isCollision = false;

    private void Awake()
    {
        HideEndScreen();
        body = GetComponent<Rigidbody2D>();
        ResetCarPosition();
        RandomSprite();
        body.velocity = new Vector2(-1 * Car2speed, 0);
    }

    private void Update()
    {
        if (body.transform.position.x < -12)
        {
            RandomSprite();
            ResetCarPosition();

            var randomSpeed = Random.Range(-1.2f, -2f) * Car2speed;
            body.velocity = new Vector2(randomSpeed, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            HideEndScreen();
            gameObject.SetActive(false);
            RandomSprite();
            StartBackground();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            ResetCarPosition();
            gameObject.SetActive(false);
            ShowEndScreen();
            StopBackground();
            _isCollision = true;
        }
    }

    private void ResetCarPosition()
    {
        body.transform.position = new Vector2(12, Random.Range(-3.5f, 3.5f));
    }

    private void RandomSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
    }

    private void ShowEndScreen()
    {
        if (_endGameScreen == null)
            _endGameScreen = GameObject.Find("EndGame");
        _endGameScreen.SetActive(true);

    }

    private void HideEndScreen()
    {
        if (_endGameScreen == null)
            _endGameScreen = GameObject.Find("EndGame");
        _endGameScreen.SetActive(false);
    }

    private void StopBackground()
    {
        var road = GameObject.Find("Background");
        road.SetActive(false);
    }

    private void StartBackground()
    {
        var road = GameObject.Find("Background");
        road.SetActive(true);
    }

        

}
   
