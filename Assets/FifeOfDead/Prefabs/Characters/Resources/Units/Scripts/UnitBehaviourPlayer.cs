using UnityEngine;
using UnityEngine.InputSystem;

namespace FifeOfDead.Units
{

    public class UnitBehaviourPlayer : IUnitBehaviour
    {
        public override void Input()
        {
            moveDirection = PlayerControlls.controlls.Main.Move.ReadValue<Vector2>();
        }
        public override void BehaviourUnit(float speed)
        {
            rb.velocity = base.GetForwardVector3() * speed * Time.fixedDeltaTime;
            if (UnityEngine.Input.GetMouseButton(1))
            {
                LookHoldMouse();
            }
            else
            {
                LookAtMove();
            }
        }
        private void LookHoldMouse()
        {
            Vector3 mousePosition = UnityEngine.Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 lookPos = new Vector3(hit.point.x, go.transform.position.y, hit.point.z);
                Quaternion targetRotation = Quaternion.LookRotation(lookPos - go.transform.position);
                float rotationSpeed = 3f;
                go.transform.rotation = Quaternion.Lerp(go.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        private void LookAtMove()
        { 
            if (rb.velocity.magnitude > 0.1f)
            {
                go.transform.rotation = Quaternion.Lerp(go.transform.rotation, Quaternion.LookRotation(rb.velocity.normalized), 10 * Time.deltaTime);
            }
        }
    }
}
