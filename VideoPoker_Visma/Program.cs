using GameManagment;

namespace VideoPoker_Visma
{
    class Program
    {
        static void Main(string[] args)
        {
            GameService uIService = new GameService();
            uIService.StartGame();

        }
    }
}
