using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Enemy : MonoBehaviour
    {
        private int m_HP = 100;
        private int m_attack = 100;
        private float m_movespeed = 100f;
        private float m_backspeed = 100f;

        private void Update()
        {
            Move(m_movespeed);
        }

        private void Move(float moveDelta)
        {
            gameObject.transform.position += Vector3.left * moveDelta * Time.deltaTime;
        }

        private void Hit(Player player)
        {
            player.GetHit(m_attack);
        }

        private void GetHit(int damage)
        {
            m_HP -= damage;

        }

        private void Die()
        {
            Destroy(gameObject);
        }

    }    
}