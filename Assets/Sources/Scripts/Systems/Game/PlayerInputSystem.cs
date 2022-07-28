using Kuhpik;
using UnityEngine;

public class PlayerInputSystem : GameSystem
{
    [SerializeField] float minDistance;

    private Vector3 firstTouchPosition;

    public override void OnInit()
    {
        firstTouchPosition = Input.mousePosition;
    }

    public override void OnUpdate()
    {
        game.SwipeDirection = Vector2.zero;

        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 direction = new Vector2(Input.mousePosition.x - firstTouchPosition.x, Input.mousePosition.y - firstTouchPosition.y);
            print(direction.magnitude);
            if (direction.magnitude > minDistance)
            {
                game.SwipeDirection = new Vector2(Mathf.Round(Input.mousePosition.x - firstTouchPosition.x),
                Mathf.Round(Input.mousePosition.y - firstTouchPosition.y)).normalized;
            }
        }
    }
}