using System.Collections.Generic;

namespace ProjectAttack
{
    public class CombatManager
    {
        public static CombatManager Instance
        {
            get
            {
                if (m_insantce == null)
                {
                    m_insantce = new CombatManager();
                }

                return m_insantce;
            }
        }

        private static CombatManager m_insantce;

        private CombatManager()
        {
            UnityEventSender.OnUnityUpdate += UnityEventSender_OnUnityUpdate;
        }


        public bool playerinput = false;
        public bool enemyInrange = false;
        private int enemytimer;


        private void UnityEventSender_OnUnityUpdate()
        {
            for(int i = 0; i < m_players.Count; i++)
            {
                m_players[i].TickDebuger();
                m_players[i].DetectInput();

            }


            for (int i = 0; i < m_enemies.Count; i++)
            {
                if (m_enemies[i].gethit_stun == false) //正常時候的移動
                {
                    m_enemies[i].Move(5f);
                }
                if (m_enemies[i].gethit_stun == true) //受擊後退
                {
                    m_enemies[i].Move(0f);
                    m_enemies[i].Move(-0.1f);
                }
                if (m_enemies[i].gethit_back == true)
                {
                    m_enemies[i].Move(-15f);
                }

                for (int j = 0; j < m_players.Count; j++) 
                {
                    if (m_enemies[i].transform.position.x <= m_players[j].m_attackpoint) //在攻擊範圍內  武器定格開啟
                    {
                        m_players[j].WeaponAttackRating();
                    }

                    if (playerinput == true) //偵測輸入的時候 所有敵人的位置
                    {
                        if (m_enemies[i].transform.position.x <= m_players[j].m_attackpoint) //在攻擊範圍內  後退開啟
                        {
                            m_enemies[i].gethit_stun = true;
                        }
                    }

                    if(m_enemies[i].gethit_stun == true)
                    {
                        enemytimer = enemytimer + 1;
                          
                        if (enemytimer >= 60)  //超過暈眩時間  後退關閉/受傷開啟
                        {
                            m_enemies[i].gethit_back = true;
                            m_enemies[i].gethit_stun = false;
                            enemytimer = 0;
                        }
                    }
                    if (m_enemies[i].gethit_back == true)
                    {
                        if (m_enemies[i].transform.position.x >= m_players[j].m_attackpoint + 2) //超出受擊後退範圍  後退關閉/受傷開啟
                        {
                            m_enemies[i].gethit_back = false;
                            m_enemies[i].hiteffect = true;


                        }
                    }

                        if (m_enemies[i].hiteffect == true) //攻擊有效開啟
                    {
                         m_players[j].HitEnemy(m_enemies[i]);
                        
                    }
                    if (m_enemies.Count <= 0) //如果都死光會報錯:out of range  所以要return
                        return;

                    if (m_enemies[i].transform.position.x <= m_players[j].transform.position.x + 0.5f)   //enemy hit player
                    {
                        m_enemies[i].HitPlayer(m_players[j]);
                        m_enemies[i].Die();
                    }


                }
            }
            playerinput = false;
        }

        private List<Player> m_players = new List<Player>();
        private List<Enemy> m_enemies = new List<Enemy>();

        public void Register(Player player)
        {
            if (m_players.Contains(player))
                return;

            m_players.Add(player);
        }

        public void Register(Enemy enemy)
        {
            if (m_enemies.Contains(enemy))
                return;

            m_enemies.Add(enemy);
        }

        public void Unregister(Player player)
        {
            if (!m_players.Contains(player))
                return;

            m_players.Remove(player);
        }

        public void Unregister(Enemy enemy)
        {
            if (!m_enemies.Contains(enemy))
                return;

            m_enemies.Remove(enemy);
        }


        }
}