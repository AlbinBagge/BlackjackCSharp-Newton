// Albin Bagge
namespace BlackjackCSharp;
public class Game
{
    public GameRules GameRules = new();
    public bool GameActive { get; set; }
    public static CardDeck s_deck { get; set; }
    public static Dealer s_dealer { get; set; }
    public static Player s_player { get; set; }
    
    public Game()
    {
        s_deck = new CardDeck();
        s_dealer = new Dealer();
        s_player = new Player("Player");
        LoopGame();
    }

    public void LoopGame()
    {
        do
        {
            GameRules.StartGame();

            // Examples:
            // GameRules.PlayerTurn();
            // GameRul.DealerTurn();
            // GameRules.WinCheck();
        }
        while (GameActive);
    }
}
