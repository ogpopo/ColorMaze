using Kuhpik;
using UnityEngine;

public class LevelLoadingSystem : GameSystem
{
    [SerializeField] string levelsPath;
    [SerializeField] int maxLevels;

    public override void OnInit()
    {
        var level = Mathf.Clamp(player.Level, 0, maxLevels - 1);
        var levelGameObject = Resources.Load<GameObject>(string.Format(levelsPath, level + 1));

        game.CurrentLevel = Instantiate(levelGameObject);
    }
}