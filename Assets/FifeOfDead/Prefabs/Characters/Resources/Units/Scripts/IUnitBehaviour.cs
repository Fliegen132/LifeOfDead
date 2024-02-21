using UnityEngine;

namespace FifeOfDead.Units
{
    public class IUnitBehaviour
    {
        protected GameObject go;
        protected Rigidbody rb;
        protected Vector2 moveDirection;
        public virtual void Enter(GameObject unit)
        {
            go = unit;
            rb = unit.GetComponent<Rigidbody>();
        }

        public virtual void Input()
        {
            
        }

        public virtual void BehaviourUnit(float speed)
        {
            
        }
        protected virtual Vector3 GetForwardVector3()
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();
            Vector3 directionVec = new Vector3(moveDirection.x, 0 ,moveDirection.y);
            Vector3 movement = (cameraForward * moveDirection.y + cameraRight * moveDirection.x).normalized;
            return movement;
        }
    }
}


