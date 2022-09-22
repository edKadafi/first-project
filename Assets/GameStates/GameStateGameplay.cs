using NotImplementedException = System.NotImplementedException;

namespace Proiect.Game.States
{
    public class GameStateGameplay : IGameState
    {
        public string StateName { get; } = "GamePlay";
        public bool isRunning { get; private set; }
        public bool isSuspended { get; private set; }
        
        public void Suspend()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void StateEnter()
        {
            isRunning = true;
            UI.UI.System.EnableHealthBar();
        }

        public void StateExit()
        {
            isRunning = false;
            UI.UI.System.DisableHealthBar();
        }
    }
}