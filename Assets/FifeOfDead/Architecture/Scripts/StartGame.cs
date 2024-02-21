using System;
using FifeOfDead.Units;
using UnityEngine;

namespace FifeOfDead.Architecture
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private Unit player; 
        private void Start()
        {
            player.Init(new UnitBehaviourPlayer());
        }
    }
}