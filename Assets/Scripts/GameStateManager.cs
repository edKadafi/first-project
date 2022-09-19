using System.Collections.Generic;

namespace Proiect.GamePlay
{
    public static class GameStateManager
    {
        private static GameplayState newState;
        private static Dictionary<int, string> states= new Dictionary<int, string>(){{0, "Main Menu"}, {1, "Pause Menu"}, {2, "Scene 1"}};
        private static GameplayState currentState;

        public static void Initialize()
        {
            newState = new GameplayState(0, states[0]);
            currentState = newState;
        }
        public static void InitializeState(int id)
        {
            newState = new GameplayState(id, states[id]);
            currentState = newState;
        }

        public static void ChangeState(int id)
        {
            newState = new GameplayState(ref currentState, id, states[id]);
            currentState = newState;
        }

        public static ref GameplayState GetCurrentStateRef()
        {
            return ref currentState;
        }

        public static GameplayState GetCurrentState()
        {
            return currentState;
        }

        public static Dictionary<int, string> StatesDict()
        {
            return states;
        }
    }
}

