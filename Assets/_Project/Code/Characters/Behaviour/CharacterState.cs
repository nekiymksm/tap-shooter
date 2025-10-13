using _Project.Code.Characters.Behaviour.Actions._Base;
using _Project.Code.Characters.Behaviour.Controllers._Base;
using UnityEngine;

namespace _Project.Code.Characters.Behaviour
{
    [CreateAssetMenu(fileName = "CharacterState", menuName = "Characters/Behaviour/CharacterState")]
    public class CharacterState : ScriptableObject
    {
        [SerializeField] private CharacterAction[] actions;
        [SerializeField] private CharacterStateTransition[] transitions;

        public void OnEnableActions(CharacterStateController stateController)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Activate(stateController);
            }
            
            for (int i = transitions.Length - 1; i >= 0; i--)
            {
                transitions[i].Decision.Activate(stateController);
            }
        }
        
        public void DoActions(CharacterStateController stateController)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Play(stateController);
            }
        }
        
        public void CheckTransitions(CharacterStateController stateController)
        {
	        for (int i = 0; i < transitions.Length; i++)
            {
	            if (transitions[i].Decision.Decide(stateController))
            	{
                    stateController.TransitionToState(transitions[i].TrueState, transitions[i].Decision);
            	}
            	else
            	{
                    stateController.TransitionToState(transitions[i].FalseState, transitions[i].Decision);
            	}
	            
	            if (stateController.CurrentState != this)
            	{
                    stateController.CurrentState.OnEnableActions(stateController);
                    break;
            	}
            }
        }
    }
}