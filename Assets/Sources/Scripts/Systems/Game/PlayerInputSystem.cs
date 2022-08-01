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

        if (Input.GetMouseButtonDown(0) || game.IsPlayerMoving)
        {
            firstTouchPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 direction = new Vector2(Input.mousePosition.x - firstTouchPosition.x, Input.mousePosition.y - firstTouchPosition.y).normalized;

            if (Vector2.Dot(Vector2.up, direction) > .9f)
            {
                game.SwipeDirection = Vector2.up;

            }
            else if (Vector2.Dot(Vector2.down, direction) > .9f)
            {
                game.SwipeDirection = Vector2.down;
            }
            else if (Vector2.Dot(Vector2.left, direction) > .9f)
            {
                game.SwipeDirection = Vector2.left;
            }
            else if (Vector2.Dot(Vector2.right, direction) > .9f)
            {
                game.SwipeDirection = Vector2.right;
            }
        }
    }
}