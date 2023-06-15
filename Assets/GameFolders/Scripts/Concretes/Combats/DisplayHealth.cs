using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject3.Combats
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += HandleOnTakeHit;
        }

        /*void OnDisable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit -= HandleOnTakeHit;
        }*/

        void HandleOnTakeHit(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
        }
    }
}

