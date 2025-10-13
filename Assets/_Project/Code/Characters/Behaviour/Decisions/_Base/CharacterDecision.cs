using _Project.Code.Characters.Behaviour.Controllers._Base;
using UnityEngine;

namespace _Project.Code.Characters.Behaviour.Decisions._Base
{
    public abstract class CharacterDecision : ScriptableObject
    {
        public abstract void Activate(CharacterStateController stateController);

        public abstract bool Decide(CharacterStateController stateController);
    }
}