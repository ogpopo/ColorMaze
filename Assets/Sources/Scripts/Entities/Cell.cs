using Kuhpik;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Renderer renderer;

    public bool IsPainted { get; private set;}

    public void PaintCell(Color newColor)
    {
        renderer.material.color = newColor;

        IsPainted = true;
    }
}