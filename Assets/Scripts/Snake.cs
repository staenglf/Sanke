using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.up;
    public GameObject segmentPrefab;
    public List<GameObject> segments = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        segments.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w") && moveDirection != Vector2.down)
        {
            moveDirection = Vector2.up;
        }
        if (Input.GetKeyDown("s") && moveDirection != Vector2.up)
        {
            moveDirection = Vector2.down;
        }
        if (Input.GetKeyDown("a") && moveDirection != Vector2.right)
        {
            moveDirection = Vector2.left;
        }
        if (Input.GetKeyDown("d") && moveDirection != Vector2.left)
        {
            moveDirection = Vector2.right;
        }
    }

    // Adds the movement to the snake
    private void movement()
    {
        transform.position = (Vector2)transform.position + moveDirection;
    }

    // Binds the snake body to the head
    private void SegmentMovement()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    // FixedUpdate is called in every frame
    private void FixedUpdate()
    {
        SegmentMovement();
        movement();
    }

    // Adds a body part to the snake
    public void ExpandSnake()
    {
        GameObject segment = Instantiate(segmentPrefab, segments[segments.Count - 1].transform.position, segmentPrefab.transform.rotation);
        segments.Add(segment);
    }

    // Is called evertime the BoxCollider is triggered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            ExpandSnake();
        }
        else
        {
            FindObjectOfType<GameManager>().RestartGame();
        }
    }
}
