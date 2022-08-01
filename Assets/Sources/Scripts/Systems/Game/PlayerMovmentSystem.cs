using Kuhpik;
using UnityEngine;
using DG.Tweening;

public class PlayerMovmentSystem : GameSystem
{
    [SerializeField] private PathBuilderSystem pathBuilderSystem;

    private float movementSpeed => .1f * game.TravelDistance;

    public override void OnInit()
    {
        pathBuilderSystem.OnHitWall += MoveToWall;
        pathBuilderSystem.OnHitPortal += MovingThroughPortal;

    }

    private void MoveToWall(Vector3 point)
    {
        Sequence sequence = DOTween.Sequence();

        game.IsPlayerMoving = true;

        sequence.Append(game.PlayerTransform.DOMove(point, movementSpeed).
            OnComplete(() => game.IsPlayerMoving = false));
    }

    private void MovingThroughPortal(Portal firstPortal, Vector3 endPoint)
    {
        Sequence sequence = DOTween.Sequence();

        game.IsPlayerMoving = true;

        var positionWithOffset = new Vector3(firstPortal.OterTeleport.transform.position.x, firstPortal.OterTeleport.transform.position.y + config.PlayerOffsetFromFloor, firstPortal.OterTeleport.transform.position.z);

        sequence.Append(game.PlayerTransform.DOMove(firstPortal.transform.position, movementSpeed)).
            AppendCallback(() => game.PlayerTransform.position = positionWithOffset);

        sequence.Append(game.PlayerTransform.DOMove(endPoint, movementSpeed)).
            AppendCallback(() => game.IsPlayerMoving = false);
    }
}