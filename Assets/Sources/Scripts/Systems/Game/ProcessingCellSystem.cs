using Kuhpik;
using UnityEngine;

public class ProcessingCellSystem : GameSystem
{
    [SerializeField] private CellTrackerComponent cellTracker;

    public override void OnInit()
    {
        game.PlayerTransform.GetComponent<CellTrackerComponent>().OnActivationNewCell += PaintCell;
    }

    private void PaintCell(Cell cellForPainting)
    {
        if (!cellForPainting.IsPainted)
        {
            cellForPainting.PaintCell(game.ChangedColorForFloor);

            game.FilledInCells++;

            if (game.FilledInCells >= game.FilledInCellsNumberToWin)
            {
                Bootstrap.Instance.ChangeGameState(GameStateID.Victory);
            }
        }
    }
}