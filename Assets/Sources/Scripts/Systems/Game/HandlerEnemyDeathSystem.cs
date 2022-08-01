using Kuhpik;
using Supyrb;
using UnityEngine;
using DG.Tweening;

public class HandlerEnemyDeathSystem : GameSystem
{
    public override void OnInit()
    {
        Signals.Get<OnFacedPlayer>().AddListener(CollisionHandling, 1);
    }

    public override void OnStateExit()
    {
        Signals.Clear();
    }

    private void CollisionHandling(GameObject enemy)
    {
        enemy.GetComponent<Animator>().enabled = false;

        enemy.transform.DOJump(enemy.transform.position + new Vector3(game.SwipeDirection.x , 1, game.SwipeDirection.y), 2, 1, 1);
    }
}