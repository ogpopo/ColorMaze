using Kuhpik;
using UnityEngine;
using DG.Tweening;

public class PlayerMovmentSystem : GameSystem
{
    public override void OnLateUpdate()
    {
        if (game.CellToMove == null)
            return;

        if (game.SwipeDirection != Vector2.zero)
        {
            game.PlayerTransform.DOMove(new Vector3(game.CellToMove.transform.position.x, game.CellToMove.transform.position.y), 2f);
        }
    }
}