namespace Kuhpik
{
    public enum GameStateID
    {
        // Don't change int values in the middle of development.
        // Otherwise all of your settings in inspector can be messed up.

        Loading = 0,
        Game = 2,
        Pause = 3,
        Victory = 10,
        Lose = 11

        // Extend just like that
        //
        // Revive = 100,
        // QTE = 200
    }
}