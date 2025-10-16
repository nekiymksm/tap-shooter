using _Project.Code.Shooting._Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Code.Shooting
{
    public class ShootingHandle : MonoBehaviour
    {
        [SerializeField] private Camera viewCamera;
    
        private InputAction shotAction;

        private void Start()
        {
            shotAction = InputSystem.actions.FindAction("Attack");
        }

        private void Update()
        {
            if (shotAction.WasPressedThisFrame())
            {
                DoShot();
            }
        }

        private void DoShot()
        {
            var shotPoint = Vector3.zero;
        
#if UNITY_ANDROID || UNITY_IOS
        shotPoint = Touchscreen.current.primaryTouch.position.ReadValue();
#elif UNITY_STANDALONE
            shotPoint = Mouse.current.position.ReadValue();
#endif
        
            var ray = viewCamera.ScreenPointToRay(shotPoint);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.PositiveInfinity))
            {
                if (hitInfo.collider.TryGetComponent(out IHitable hitable))
                {
                    hitable.TakeHit(hitInfo.point);
                }
            }
        }
    }
}