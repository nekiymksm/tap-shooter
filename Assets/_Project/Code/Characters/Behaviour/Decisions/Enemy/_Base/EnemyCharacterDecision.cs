using _Project.Code.Characters.Behaviour.Controllers;
using _Project.Code.Characters.Behaviour.Controllers._Base;
using _Project.Code.Characters.Behaviour.Decisions._Base;

namespace _Project.Code.Characters.Behaviour.Decisions.Enemy._Base
{
    public abstract class EnemyCharacterDecision : CharacterDecision
    {
        public sealed override void Activate(CharacterStateController stateController)
        {
            if (stateController.GetType() == typeof(EnemyStateController))
            {
                OnActivate((EnemyStateController)stateController);
            }
        }

        public sealed override bool Decide(CharacterStateController stateController)
        {
            if (stateController.GetType() == typeof(EnemyStateController))
            {
                return OnDecide((EnemyStateController)stateController);
            }

            return false;
        }
        
        protected abstract void OnActivate(EnemyStateController enemyStateController);
        
        protected abstract bool OnDecide(EnemyStateController enemyStateController);
    }
}