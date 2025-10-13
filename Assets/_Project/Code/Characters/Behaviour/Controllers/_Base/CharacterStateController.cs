using _Project.Code.Characters.Behaviour.Decisions._Base;
using UnityEngine;

namespace _Project.Code.Characters.Behaviour.Controllers._Base
{
    public abstract class CharacterStateController : MonoBehaviour
    {
        [SerializeField] private CharacterState startState;
        [SerializeField] private CharacterState remainState;

        public CharacterState CurrentState { get; private set; }

        private void Start()
        {
            CurrentState = startState;
            CurrentState.OnEnableActions(this);
            
            OnActivate();
        }

        private void Update()
        {
            CurrentState.DoActions(this);
            CurrentState.CheckTransitions(this);
            
            OnPlay();
        }

        public void TransitionToState(CharacterState nextState, CharacterDecision decision)
        {
            if (nextState != remainState)
            {
                Debug.LogError("TEST");
                CurrentState = nextState;
            }
        }

        protected virtual void OnActivate()
        {
        }
        
        protected virtual void OnPlay()
        {
        }
    }
}