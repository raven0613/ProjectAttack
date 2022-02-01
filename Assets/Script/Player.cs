using UnityEngine;

namespace ProjectAttack
{
    public class Player : MonoBehaviour
    {
        private class Debuger
        {
            private Player m_player;

            public Debuger(Player player)
            {
                m_player = player;
            }

            public void Tick()
            {
                if(Input.GetKeyDown(KeyCode.S))
                {
                    ForceDie();
                }

                if(CombatManager.Instance.playerinput == true)
                {
                    Debug.Log("player input O");
                }

            }

            private void ForceDie()
            {
                m_player.GetHit(9999);
            }
        }

        private enum CharacterState
        {
            Alive,
            Died
        }

        [SerializeField] private Weapon m_weapon;

        private int m_hp = 200;
        private int m_attack = 100;
        private float m_attackrange = 2f;
        public float m_attackpoint;


        private CharacterState m_state = CharacterState.Alive;

        private Debuger m_debuger;

        private void Awake()
        {
            m_debuger = new Debuger(this);
            CombatManager.Instance.Register(this);

            m_attackpoint = gameObject.transform.position.x + m_attackrange;
        }

        //private void Update()
        //{
        //    m_debuger.Tick();

        //    switch(m_state)
        //    {
        //        case CharacterState.Alive:
        //            {
        //                DetectInput();
        //                break;
        //            }
        //        case CharacterState.Died:
        //            {
        //                break;
        //            }
        //    }
        //}

        public void TickDebuger()
        {
            m_debuger.Tick();
        }

        public void DetectInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CombatManager.Instance.playerinput = true;
                Attack();

            }

        }

        private void Attack()
        {
            m_weapon.StartRotate();

        }

        public void HitEnemy(Enemy enemy)
        {
            enemy.GetHit(m_attack);
        }
        public void WeaponAttackRating()
        {
            m_weapon.AttackRating();
        }

        public void GetHit(int damage)
        {
            if (m_state != CharacterState.Alive)
                return;

            m_hp -= damage;

            if (m_hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            m_state = CharacterState.Died;
            gameObject.SetActive(false);


        }

    }
}