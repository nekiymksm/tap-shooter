using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

namespace _Project.Code.Shooting
{
    public class AimingHandle : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 100.0f)] private float speed;

        private InputAction jumpAction;
        private Vector3 startRotation;

        private void Start()
        {
            jumpAction = InputSystem.actions.FindAction("Jump");
            startRotation = transform.rotation.eulerAngles;
        }

        private void Update()
        {
            if (jumpAction.WasPressedThisFrame())
            {
                transform.rotation = Quaternion.Euler(startRotation);
            }
            
            if (Gyroscope.current != null)
            {
                InputSystem.EnableDevice(Gyroscope.current);
            
                if (Gyroscope.current.enabled)
                {
                    Vector3 angularVelocity = Gyroscope.current.angularVelocity.ReadValue();
                    transform.Rotate(-angularVelocity * speed * Time.deltaTime);

                    var rot = transform.rotation.eulerAngles;
                    rot.x = Mathf.Clamp(Mathf.DeltaAngle(0, rot.x), -10, 20) + 360;
                    rot.y = Mathf.Clamp(Mathf.DeltaAngle(0, rot.y), -25, 25) + 360;
                    rot.z = 0;
                    
                    transform.rotation = Quaternion.Euler(rot);
                }
            }
            
            Quaternion targetRotation = Quaternion.Euler(startRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f * Time.deltaTime);
        }

        private void OnDestroy()
        {
            if (Gyroscope.current != null)
            {
                InputSystem.DisableDevice(Gyroscope.current);
            }
        }
    }
}