using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP= 300;
        private int  m_attack = 100;
        //private float m_movespeed = 100f;
        //private float m_backspeed = 100f;

        public bool gethit;
        private void Awake()
        {
            CombatManager.Instance.Register(this);
            gethit = false;
        }



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
            CombatManager.Instance.playerinput = false;

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

    }    
}