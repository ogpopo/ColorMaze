using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class PathBuilderSystem : GameSystem
{
    [SerializeField] [Tag] private string cellTag;

    public override void OnUpdate()
    {
        GameObject selectedTile;

        if (game.SwipeDirection != Vector2.zero)
        {
            game.CellToMove = null;

            RaycastHit hit;

            if (Physics.Raycast(game.CurrentCell.position, new Vector3(game.SwipeDirection.x, game.SwipeDirection.y, 0), out hit))
            {
                selectedTile = hit.transform.gameObject;

                if (!CheckingForCell(selectedTile))
                    return;
                print(game.SwipeDirection);

                print("444");
                if (Physics.Raycast(selectedTile.transform.position, new Vector3(game.SwipeDirection.x, game.SwipeDirection.y, 0), out hit))
                {
                    print("555");
                    if (CheckingForCell(hit.transform.gameObject))
                    {
                        print("666");
                        game.CellToMove = selectedTile.transform;
                    }

                    selectedTile = hit.transform.gameObject;
                }

            }
        }
    }

    private bool CheckingForCell(GameObject cellForCheck)
    {
        return cellForCheck.CompareTag(cellTag);
    }
}