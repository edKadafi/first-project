using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;
using Proiect.UI;

namespace Proiect.Game.States
{
    public class GameStateMainMenu : IGameState
    {
        public string StateName { get; } = "MainMenu";
        public bool isRunning { get; }
        public bool isSuspended { get; }

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
            
        }

        public void StateExit()
        {
            
        }
    }
}