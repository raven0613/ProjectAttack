using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Player : MonoBehaviour
    {
        private CharacterData m_characterData;

        public float StartPosition = 1f;

        public static Player instance;

        public int PlayerHP;
        public int PlayerAttack;
        public float PlayerAttackRange;
        


        public bool Player_isAlive = true;

        private void Awake()
        {
            m_characterData = CharacterData.GetTestData();
            instance = this;

            PlayerHP = m_characterData.HP;
            PlayerAttack = m_characterData.Attack;
            PlayerAttackRange = m_characterData.AttackRange + gameObject.transform.position.x;
            Player_isAlive = true;

            StartPosition = gameObject.transform.position.x;
        }

        private void Update()
        {
            if(PlayerHP > 0)
            {
                Player_isAlive = true;
            }

            if(PlayerHP <= 0)
            {
                PlayerHP = 0;
                gameObject.SetActive(false);
                Debug.Log("PlayerDead");
                Player_isAlive = false;
            }

        }

        public void GameRestart()
        {
            PlayerHP = m_characterData.HP;
            gameObject.SetActive(true);
        }
    }
}