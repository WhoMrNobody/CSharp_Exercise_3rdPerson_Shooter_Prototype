using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controller;
using UdemyProject3.Abstract.Controllers;
using UnityEngine;


namespace UdemyProject3.Animations
{
    public class CharacterAnimation 
    {
        Animator _animator;

        public CharacterAnimation(IEntityController entityController)
        {
            _animator= entityController.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if(_animator.GetFloat("moveSpeed") == moveSpeed) { return; }

            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

        public void AttackAnimation(bool isAttacking)
        {
            _animator.SetBool("isAttacking", isAttacking);
        }

        public void DeadAnimation(string animationParameter)
        {
            _animator.SetTrigger(animationParameter);
        }
    }

}
