using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int xBound = 18;
    private int yBound = 9;

    public Snake sn;
    private List<Vector2> emptySpace = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    // Fill a list with all possible positions for a food rectangle
    private void calculateEmptySpace()
    {
        emptySpace.Clear();

        for(int x = -xBound; x <= xBound; x++)
        {
            for (int y = -yBound; y <= yBound; y++)
            {
                emptySpace.Add(new Vector2(x, y));
            }
        }

        // Removes the positions which are blocked by the snake
        foreach(GameObject segment in sn.segments) 
        {
            int x = Mathf.RoundToInt(segment.transform.position.x);
            int y = Mathf.RoundToInt(segment.transform.position.y);
            Vector2 pos = new Vector2(x, y);
            emptySpace.Remove(pos);
        }
    }

    // Select a random coordinate out of the list
    private void randomPosition()
    {
        calculateEmptySpace();
        Vector2 newRandomPosition = emptySpace[Random.Range(0, emptySpace.Count)];
        transform.position = newRandomPosition;
    }

    // Is called evertime the BoxCollider is triggered
    private void OnTriggerEnter2D(Collider2D colission)
    {
        randomPosition();
        FindObjectOfType<GameManager>().IncreaseScore();
    }
}
