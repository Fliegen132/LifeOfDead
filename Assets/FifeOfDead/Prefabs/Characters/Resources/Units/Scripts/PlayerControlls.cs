using UnityEngine;

namespace FifeOfDead.Units
{
    public class PlayerControlls : MonoBehaviour
    {
        public static Controlls controlls;
        public void Awake()
        {
            controlls = new Controlls();
            controlls.Enable();
        }
    }
}