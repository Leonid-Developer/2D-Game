using UnityEngine;
public class Square : MonoBehaviour
{
    public Player Player;

    public GameObject playerObj;

    public Vector2 targetPosition;

    public float moveStep;

    public bool isTrap;

    void Start()
    {
        targetPosition = GetRandomPoint();
        if(isTrap == false)
        {
            Player.squares.Add(this);
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);

        if((Vector2)transform.position == targetPosition)
        {
            targetPosition = GetRandomPoint();
        }
    }

    Vector2 GetRandomPoint()
    {
        Vector2 randomVector = new Vector2();

        randomVector.x = Random.Range(-6,6);
        randomVector.y = Random.Range(-3, 3);

        return randomVector;
    }
    private void OnMouseDown()
    {
        print("OK");
        if (isTrap)
        {
            Player.Defeat();
        }
        else
        {
            Catch();
        }
    }

    public float speedFactor;
    public float scaleFactor;

    public int catchCount;

    void Catch()
    {
        Player player = playerObj.GetComponent<Player>();
        Player.score++;

        catchCount--;
        if(catchCount == 0)
        {
            Player.squares.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
            transform.position = GetRandomPoint();
        }
    }
}
