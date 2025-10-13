using System;
using _Project.Code.Characters.Behaviour.Decisions._Base;

namespace _Project.Code.Characters.Behaviour
{
    [Serializable]
    public class CharacterStateTransition
    {
        public CharacterDecision Decision;
        public CharacterState TrueState;
        public CharacterState FalseState;
    }
}