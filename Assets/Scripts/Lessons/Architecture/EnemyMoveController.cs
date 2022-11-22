﻿using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class EnemyMoveController : AbstractMoveController
    {
        [SerializeField] private Enemy _enemy;

        /*private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }*/

        protected override void Move(Vector3 direction)
        {
            const float speed = 5.0f;
            _enemy.Move(direction * (speed * Time.deltaTime));
        }
    }
}