using _Project.Code.Characters.Behaviour.Actions._Base;
using _Project.Code.Characters.Behaviour.Controllers;
using _Project.Code.Characters.Behaviour.Controllers._Base;

namespace _Project.Code.Characters.Behaviour.Actions.Enemy._Base
{
    public abstract class EnemyCharacterAction : CharacterAction
    {
        public sealed override void Activate(CharacterStateController stateController)
        {
            if (stateController.GetType() == typeof(EnemyStateController))
            {
                OnActivate((EnemyStateController)stateController);
            }
        }

        public sealed override void Play(CharacterStateController stateController)
        {
            if (stateController.GetType() == typeof(EnemyStateController))
            {
                OnPlay((EnemyStateController)stateController);
            }
        }

        protected abstract void OnActivate(EnemyStateController enemyStateController);

        protected abstract void OnPlay(EnemyStateController enemyStateController);
    }
}