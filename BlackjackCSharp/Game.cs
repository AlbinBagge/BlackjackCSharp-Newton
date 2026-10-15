// Albin Bagge
namespace BlackjackCSharp;
public class Game
{
    public GameRules GameRul = new();
    public bool GameActive { get; set; }
    public static CardDeck DeckObject { get; set; }
    public static Dealer DealerObject { get; set; }
    public static Player PlayerObject { get; set; }
    
    public Game()
    {
        DeckObject = new CardDeck();
        DealerObject = new Dealer();
        PlayerObject = new Player("Player");
        LoopGame();
    }

    public void LoopGame()
    {
        do
        {
            GameRul.StartGame();

            // Examples:
            // GameRules.PlayerTurn();
            // GameRul.DealerTurn();
            // GameRules.WinCheck();
        }
        while (GameActive);
    }
}
