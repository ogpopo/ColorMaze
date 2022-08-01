using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class LevelLoadingSystem : GameSystem
{
    [SerializeField] [Tag] private string playerTag;

    [SerializeField] string levelsPath;
    [SerializeField] int maxLevels;

    [SerializeField] GameObject cellPrefab;
    [SerializeField] GameObject backgroundPrefab;

    private LevelSettingsComponent levelSettings;

    public override void OnInit()
    {
        var level = Mathf.Clamp(player.Level, 0, maxLevels - 1);
        var levelGameObject = Resources.Load<GameObject>(string.Format(levelsPath, level + 1));

        game.CurrentLevel = Instantiate(levelGameObject);
        game.PlayerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;


        levelSettings = game.CurrentLevel.gameObject.GetComponent<LevelSettingsComponent>();

        SyncingWithGameData();
        SettingEnvironment();
    }

    private void SyncingWithGameData()
    {
        game.ColorForPlayer = levelSettings.ColorForPlayer;
        game.ColorForBackground = levelSettings.ColorForBackground;
        game.DefaultColorForFloor = levelSettings.DefaultColorForFloor;
        game.ChangedColorForFloor = levelSettings.ChangedColorForFloor;
    }

    private void SettingEnvironment()
    {
        game.PlayerTransform.GetComponent<Renderer>().material.color = game.ColorForPlayer;
        backgroundPrefab.GetComponent<Renderer>().sharedMaterial.color = game.ColorForBackground;
        cellPrefab.GetComponent<Renderer>().sharedMaterial.color = game.DefaultColorForFloor;
    }
}