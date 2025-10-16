using UnityEngine;

namespace _Project.Code.Shooting._Base
{
    public interface IHitable
    {
        public void TakeHit(Vector3 hitPoint);
    }
}