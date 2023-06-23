using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UdemyProject3.Managers;
using System;

namespace UdemyProject3.UI
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        TMP_Text _waveLevelText;

        void Awake()
        {
            _waveLevelText = GetComponent<TMP_Text>();
        }

        void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextLevel;
        }

        void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextLevel;
        }
        
        void HandleOnNextLevel(int levelValue)
        {
            _waveLevelText.text = levelValue.ToString();
        }
    }
}

