using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP= 5000;
        private int  m_attack = 100;
        //private float m_movespeed = 100f;
        //private float m_backspeed = 100f;

        public bool gethitback;
        public bool hiteffect;
        private void Awake()
        {
            CombatManager.Instance.Register(this);
            gethitback = false;
            hiteffect = false;
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
            if (hiteffect == true)
            {
                m_HP -= damage;

                

                if (m_HP <= 0)
                {
                    Die();

                }

                hiteffect = false;

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