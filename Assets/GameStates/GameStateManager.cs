using System.Collections.Generic;
using UnityEngine;

namespace Proiect.GamePlay
{
    public static class GameStateManager
    {
        public static IGameState CurrentState { get; private set; }

        public static void TransitionTo(IGameState newState)
        {
            Debug.Log("[GameStateManager] Transitioning: "+CurrentState.StateName+" - "+newState.StateName);
            newState.StateEnter();
            CurrentState.StateExit();
            CurrentState = newState;
            Debug.Log("[GameStateManager] Game State = "+CurrentState.StateName);
        }
    }
}

