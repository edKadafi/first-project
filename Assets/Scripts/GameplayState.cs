using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Proiect.GamePlay
{
    public class GameplayState : IGameState
    {
        private string name;
        private int id;
        private GameplayState lastState;
        
        public void TransitionTo()
        {
            throw new NotImplementedException();
        }

        public GameplayState(int id, string n)
        {
            name = n;
            this.id = id;
        }

        public GameplayState(ref GameplayState lState, int id, string n)
        {
            lastState = lState;
            this.id = id;
            name = n;
        }

        public string GetName()
        {
            return name;
        }
    }
}

