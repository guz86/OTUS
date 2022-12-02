﻿using UnityEngine;

namespace HomeWork
{
    public class JumpController : AbstractJumpController
    {
        [SerializeField] private Entity _unit;

        private IJumpComponent _jumpComponent;

        private void Awake()
        {
            _jumpComponent = _unit.Get<IJumpComponent>();
        }
        
        protected override void Jump()
        {
            _jumpComponent.Jump();
        }
    } 
}