using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP= 200;
        private int  m_attack = 100;

        public bool gethit_back;
        public bool hiteffect;
        public bool gethit_stun;
        private void Awake()
        {
            CombatManager.Instance.Register(this);
            gethit_back = false;
            hiteffect = false;
            gethit_stun = false;
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
            Debug.Log("hit enemy");
            m_HP -= damage;

            hiteffect = false;

            if (m_HP <= 0)
            {
               Die();
            }
        }
        public void Die()
        {
            Destroy(gameObject);
            CombatManager.Instance.Unregister(this);
        }


    }    
}