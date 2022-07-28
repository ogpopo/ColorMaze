using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class PlayerLoadingSystem : GameSystem
{
    [SerializeField] [Tag] private string playerTag;

    public override void OnInit()
    {
        game.PlayerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}