namespace BlackjackCSharp;

class Program
{
    static void Main(string[] args)
    {
        /* feature-spelregler notes:
         * 
         * StartGame()
         * - Deal initial two cards for player & dealer
         * - Make checks
         * 
         * Potential other methods:
         * - PlayerTurn()
         * - DealerTurn()
         * - WinChecks()
         */

        GameRules gameRules = new();

        // Initial card draws & checks:
        gameRules.StartGame();

        // Player Hit loop
        // - Player Hit or Stay
        // - Check for loss: Bust (but account for Ace)

        // Dealer Hit loop
        // - Until 17 or higher
        // - Check for win: dealer Bust (but account for Ace)

        // Compare hands, check for win, loss or stalemate
    }
}