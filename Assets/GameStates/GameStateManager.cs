using System.Collections.Generic;
using UnityEngine;

namespace Proiect.Game.States
{
    public static class GameStateManager
    {
        public static IGameState CurrentState { get; private set; }
        private static GameStateMainMenu _mainMenu;
        private static GameStateGameplay _gameplay;
        private static Dictionary<string, IGameState> _statesDict;
        
        static GameStateManager()
        {
            _gameplay = new GameStateGameplay();
            _mainMenu = new GameStateMainMenu();
            CurrentState = _gameplay;
            UI.UI.System.InstantiateHealthBar();
            CurrentState.StateEnter();
            _statesDict = new Dictionary<string, IGameState>() { { "MainMenu", _mainMenu }, { "GamePlay", _gameplay } };
            
        }

        public static void TransitionTo(string newStateName)
        {
            Debug.Log("[GameStateManager] Transitioning: " + CurrentState.StateName + " - " + _statesDict[newStateName].StateName);
            CurrentState.StateExit();
            _statesDict[newStateName].StateEnter();
            CurrentState = _statesDict[newStateName];
            Debug.Log("[GameStateManager] Game State = " + CurrentState.StateName);
        }
    }
}