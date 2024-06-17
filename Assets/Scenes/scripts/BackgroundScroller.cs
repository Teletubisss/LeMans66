
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float titleSizeX;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var newPosition = Mathf.Repeat(Time.time * scrollSpeed, titleSizeX);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
