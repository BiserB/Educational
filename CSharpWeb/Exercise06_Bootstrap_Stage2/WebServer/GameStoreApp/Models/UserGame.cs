namespace HTTPServer.GameStoreApp.Models
{
    public class UserGame
    {
        public UserGame(int userId, int gameId)
        {
            this.UserId = userId;
            this.GameId = gameId;
        }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}