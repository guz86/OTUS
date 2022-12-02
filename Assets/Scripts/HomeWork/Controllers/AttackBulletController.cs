﻿using UnityEngine;

namespace HomeWork
{
    public class AttackBulletController : MonoBehaviour, IStartGameListener,
        IFinishGameListener, IPauseGameListener
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackBulletInput _input;


        private IAttackBulletComponent _attackBulletComponent;

        private void Awake()
        {
            _attackBulletComponent = _unit.Get<IAttackBulletComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            _input.OnAttack += OnAttack;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnAttack -= OnAttack;
        }
        
        void IPauseGameListener.OnPauseGame()
        {
            enabled = false;
        }

        private void OnAttack()
        {
            _attackBulletComponent.Attack();
        }
    }
}