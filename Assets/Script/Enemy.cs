using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{   public class Enemy : MonoBehaviour
    {
        private CharacterData m_characterData;

        public float HurtPosition;

        public int EnemyHP;
        public int EnemyAttack;
        public float EnemyMoveSpeed;

        public float BackSpeed;
        public bool EnemyisHit;
        private void Awake()
        {
            m_characterData = CharacterData.GetTestData();
            EnemyHP = m_characterData.HP + 20;
            EnemyAttack = m_characterData.Attack;
            EnemyMoveSpeed = m_characterData.MoveSpeed;

            EnemyisHit = false;

            BackSpeed = 30f;

            //HurtPosition = Player.instance.StartPosition +0.5f;
            HurtPosition = -3.5f;
        }

        private void Update()
        {
            transform.position += Vector3.left * EnemyMoveSpeed * Time.deltaTime;


            HurtPlayer();
            EnemygotHurt();
            EnemyDead();


            if (EnemyisHit == true)
            {
                EnemyhurtMove();

                if (Player.instance.Player_isAlive == true)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BackSpeed = 30;
                        if (gameObject.transform.position.x >= Player.instance.PlayerAttackRange)
                        {
                            EnemyisHit = false;
                        }
                    }
                }
            }

        }

        private void HurtPlayer()
        {
            if(gameObject.transform.position.x <= HurtPosition)
            {
                Player.instance.PlayerHP = Player.instance.PlayerHP - EnemyAttack;

                Destroy(gameObject);
            }
        }

        private void EnemygotHurt()
        {
            if(Player.instance.Player_isAlive == true)
            {
                if (gameObject.transform.position.x <= Player.instance.PlayerAttackRange)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                    {
                        EnemyisHit = true;
                        EnemyHP = EnemyHP - Player.instance.PlayerAttack;

                    }
                }
            }


        }

        private void EnemyhurtMove()
        {
            

            BackSpeed = BackSpeed - 200 * Time.deltaTime;
            if (BackSpeed <= 0)
            {
                BackSpeed = 0;
            }
            EnemyMoveSpeed = 0;
            gameObject.transform.position = gameObject.transform.position + Vector3.right * BackSpeed * Time.deltaTime;


            EnemyMoveSpeed = EnemyMoveSpeed + 800 * Time.deltaTime;
            if (EnemyMoveSpeed >= m_characterData.MoveSpeed)
            {
                EnemyMoveSpeed = m_characterData.MoveSpeed;
            }
            gameObject.transform.position += Vector3.left * EnemyMoveSpeed * Time.deltaTime;
        }

        

        private void EnemyDead()
        {
            if(EnemyHP <= 0)
            {
                Debug.Log("EnemyDead");
                Destroy(gameObject);
            }

        }
    }    
}