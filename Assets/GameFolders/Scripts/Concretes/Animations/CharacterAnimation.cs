using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controller;
using UnityEngine;


namespace UdemyProject3.Animations
{
    public class CharacterAnimation 
    {
        Animator _animator;

        public CharacterAnimation(PlayerController playerController)
        {
            _animator= playerController.GetComponent<Animator>();
        }

        public void MoveAnimations()
        {

        }
    }

}
