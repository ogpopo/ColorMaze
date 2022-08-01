using Kuhpik;
using NaughtyAttributes;
using System;
using UnityEngine;

public class PathBuilderSystem : GameSystem
{
    [SerializeField] [Tag] private string wallTag;

    [SerializeField] private LayerMask EmptyLayer;

    public event Action<Vector3> AAA;

    public override void OnUpdate()
    {
        if (game.SwipeDirection != Vector2.zero)
        {
            RaycastHit hit;

            if (Physics.Raycast(game.PlayerTransform.position, new Vector3(game.SwipeDirection.x, 0, game.SwipeDirection.y), out hit, 30, EmptyLayer))
            {
                var positionForMove = hit.transform.position - new Vector3(game.SwipeDirection.x, 0 , game.SwipeDirection.y);

                game.TravelDistance = positionForMove.magnitude;

                if (!CheckingForHittingWall(hit))
                    return;

                AAA?.Invoke(positionForMove);
            }
        }
    }

    private bool CheckingForHittingWall(RaycastHit cellForCheck)
    {
        return cellForCheck.transform.CompareTag(wallTag);
    }
}