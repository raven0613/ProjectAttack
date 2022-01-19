using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP = 100;
        private int  m_attack { get; set; } = 100; 
        //private float m_movespeed = 100f;
        //private float m_backspeed = 100f;

        private void Awake()
        {
            CombatManager.Instance.Register(this);
        }

        //private void Update()
        //{
        //    Move(m_movespeed);
        //}

        public void Move(float moveDelta)
        {
            gameObject.transform.position += Vector3.left * moveDelta * Time.deltaTime;

        }

        public void Hit(Player player)
        {
            player.GetHit(m_attack);
        }

        public void GetHit(int damage)
        {
            m_HP -= damage;

        }



        public void Die()
        {
            Destroy(gameObject);
        }


    }    
}