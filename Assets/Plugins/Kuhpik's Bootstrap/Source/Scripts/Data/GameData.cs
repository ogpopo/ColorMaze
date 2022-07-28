using System;
using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;

        public int FieldHeight;
        public int FieldWidth;

        public GameObject CurrentLevel;

        public Transform PlayerTransform;
        public Vector2 SwipeDirection;

        public Transform CurrentCell;
        public Transform CellToMove;
    }
}