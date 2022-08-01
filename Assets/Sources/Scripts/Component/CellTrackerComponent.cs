using UnityEngine;
using System;

public class CellTrackerComponent : MonoBehaviour
{
    public event Action<Cell> OnActivationNewCell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cell cell))
        {
            OnActivationNewCell?.Invoke(cell);
        }
    }
}