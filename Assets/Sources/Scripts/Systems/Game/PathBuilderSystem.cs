using Kuhpik;
using NaughtyAttributes;
using System;
using UnityEngine;

public class PathBuilderSystem : GameSystem
{
    [SerializeField][Tag] private string wallTag;
    [SerializeField][Tag] private string portalTag;

    [SerializeField] private LayerMask emptyLayer;

    public event Action<Vector3> OnHitWall;
    public event Action<Portal, Vector3> OnHitPortal;

    public override void OnUpdate()
    {
        if (game.SwipeDirection != Vector2.zero)
        {
            RaycastHit hit1;

            if (Physics.Raycast(game.PlayerTransform.position, new Vector3(game.SwipeDirection.x, 0, game.SwipeDirection.y), out hit1, 30, emptyLayer))
            {
                var positionForMove = ReturnPositionTakingAccountOffset(hit1.transform.position);

                game.TravelDistance = positionForMove.magnitude;

                if (hit1.transform.CompareTag(wallTag))
                {
                    OnHitWall?.Invoke(positionForMove);
                }
                else if (hit1.transform.CompareTag(portalTag))
                {
                    RaycastHit hit2;

                    var firstPortal = hit1.transform.GetComponent<Portal>();

                    if (Physics.Raycast(new Vector3(firstPortal.OterTeleport.transform.position.x, config.PlayerOffsetFromFloor, firstPortal.OterTeleport.transform.position.z), new Vector3(game.SwipeDirection.x, 0, game.SwipeDirection.y), out hit2, 30, emptyLayer))
                    {
                        OnHitPortal?.Invoke(firstPortal, ReturnPositionTakingAccountOffset(hit2.transform.position));
                        print(hit2.transform.name);
                    }
                }
            }
        }
    }

    private Vector3 ReturnPositionTakingAccountOffset(Vector3 positionBefore)
    {
        return positionBefore - new Vector3(game.SwipeDirection.x, 0, game.SwipeDirection.y);
    }
}