﻿using System;
using UnityEngine;

namespace SGOAP.Examples
{
    public class Character : MonoBehaviour, ICharacter
    {
        public int foodtype = 0;
        public int sueñomod = 1;
        public int tasacansancion = 8;
        public int HP = 10;
        public int MaxHP = 10;

        public System.Action OnHealthChanged;
        public virtual void TakeDamage(int amount)
        {
            HP -= amount;
            Debug.Log($"{transform.name} took {amount} damage!");
            OnHealthChanged?.Invoke();
        }

        public virtual void AddHealth(int amount)
        {
            HP = Mathf.Clamp(HP + amount, 0, MaxHP);
            OnHealthChanged?.Invoke();
        }

        public bool IsDead()
        {
            return HP <= 0 || !gameObject.activeInHierarchy;
        }
    }
}