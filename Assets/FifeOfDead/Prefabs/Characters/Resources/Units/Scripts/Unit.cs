using System;
using System.Collections;
using System.Collections.Generic;
using FifeOfDead.Units;
using Unity.VisualScripting;
using UnityEngine;

namespace FifeOfDead.Units
{
    [RequireComponent(typeof(Rigidbody))]
    public class Unit : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private IUnitBehaviour _behaviour;
        private Rigidbody _rigidbody;
        #region mono
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        #endregion
        
        private void FixedUpdate()
        {
            _behaviour?.BehaviourUnit(_speed);
        }
        private void Update()
        {
            _behaviour?.Input();
        }
        
        public void Init(IUnitBehaviour behaviour)
        {
            _behaviour = behaviour;
            _behaviour.Enter(this.gameObject);
        }

        public void SetBehaviour(IUnitBehaviour behaviour)
        {
            if (behaviour != _behaviour)
            {
                _behaviour = behaviour;
                _behaviour.Enter(this.gameObject);
            }
        }
    }
}
