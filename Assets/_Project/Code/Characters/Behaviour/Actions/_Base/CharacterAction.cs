using _Project.Code.Characters.Behaviour.Controllers._Base;
using UnityEngine;

namespace _Project.Code.Characters.Behaviour.Actions._Base
{
    public abstract class CharacterAction : ScriptableObject
    {
        public abstract void Activate(CharacterStateController stateController);
        
        public abstract void Play(CharacterStateController stateController);
    }
}