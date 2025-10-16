using _Project.Code.Shooting._Base;
using UnityEngine;

namespace _Project.Code.Characters.Chars.Enemy._Base
{
    public abstract class EnemyCharacter : MonoBehaviour, IHitable
    {
        public void TakeHit(Vector3 hitPoint)
        {
            Debug.LogError(hitPoint);
        }
    }
}