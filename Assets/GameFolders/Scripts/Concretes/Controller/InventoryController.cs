using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controller;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] WeaponController[] _weaponControllers;

    public WeaponController CurrentWeapon { get; private set; }

    Animator _animator;
    byte _weaponIndex;
    void Awake()
    {
        _weaponControllers = GetComponentsInChildren<WeaponController>();

        foreach(WeaponController weaponController in _weaponControllers)
        {
            weaponController.gameObject.SetActive(false);
        }

        _animator =GetComponentInChildren<Animator>();
    }

    void Start()
    {
        CurrentWeapon = _weaponControllers[_weaponIndex];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void ChangeWeapon()
    {
        _weaponIndex++;

        if(_weaponIndex >= _weaponControllers.Length)
        {
            _weaponIndex = 0;
        }

        CurrentWeapon = _weaponControllers[_weaponIndex];

        foreach (WeaponController weaponController in _weaponControllers)
        {
            if(CurrentWeapon == weaponController)
            {
                weaponController.gameObject.SetActive(true);
                _animator.runtimeAnimatorController = CurrentWeapon.attackSO.AnimOverrideController;
            }
            else
            {
                weaponController.gameObject.SetActive(false);
            }
        }
    }
}
