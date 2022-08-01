using Kuhpik;
using UnityEngine;
using DG.Tweening;

public class PlayerMovmentSystem : GameSystem
{
    [SerializeField] private PathBuilderSystem pathBuilderSystem;

    Sequence sequence = DOTween.Sequence();

    private float movementSpeed => .1f * game.TravelDistance;

    public override void OnInit()
    {
        Sequence sequence = DOTween.Sequence();

        pathBuilderSystem.AAA += MoveTo;
    }

    private void MoveTo(Vector3 point)
    {
        game.IsPlayerMoving = true;

        sequence.Append(game.PlayerTransform.DOMove(point, movementSpeed).
            OnComplete(() => game.IsPlayerMoving = false));
    }
}