// Albin Bagge
namespace BlackjackCSharp;
public class Game
{
    public bool GameActive { get; set; }
    public Game()
    {
        LoopGame();
    }

    public void LoopGame()
    {
        do
        {
            gameRules.GameStart();

            // Examples:
            // gameRules.PlayerTurn();
            // gameRules.DealerTurn();
            // gameRules.WinCheck();
        }
        while (GameActive);
    }
}
