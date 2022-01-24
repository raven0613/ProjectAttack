using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP= 100;
        private int  m_attack = 100; 
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

        public void HitPlayer(Player player)
        {
            player.GetHit(m_attack);
        }

        public void GetHit(int damage)
        {
            m_HP -= damage;

            Move(-5);

            if (m_HP <= 0)
            {
                Die();
            }

            Debug.Log("hit enemy");
        }


        public void Die()
        {
            Destroy(gameObject);
            CombatManager.Instance.Unregister(this);
            
        }
        //先註銷再摧毀=搜不到
        //先摧毀再註銷=會報錯
    }    
}