// Albin Bagge
namespace BlackjackCSharp;
public class Game
{
    public GameRules gameRules = new();
    public bool GameActive { get; set; }
    public Game()
    {
        LoopGame();
    }

    public void LoopGame()
    {
        do
        {
            gameRules.StartGame();

            // Examples:
            // gameRules.PlayerTurn();
            // gameRules.DealerTurn();
            // gameRules.WinCheck();
        }
        while (GameActive);
    }
}
