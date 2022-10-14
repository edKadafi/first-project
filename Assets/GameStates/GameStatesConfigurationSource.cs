using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proiect.Game.States
{
    [CreateAssetMenu(fileName = "GameStatesConfiguration", menuName = "ScriptableObjects/GameStatesConfiguration")]
    public class GameStatesConfigurationSource : ScriptableObject
    {
        public Object[] GameStatesArray;
    }
}

