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

        private void UnityEventSender_OnUnityUpdate()
        {
            for(int i = 0; i < m_players.Count; i++)
            {
                m_players[i].TickDebuger();
                m_players[i].DetectInput();

            }


            for (int i = 0; i < m_enemies.Count; i++)
            {
                if(m_enemies[i].gethitback == false) //正常時候
                {
                    m_enemies[i].Move(5f);
                }
                if (m_enemies[i].gethitback == true) //受擊後退
                {
                    m_enemies[i].Move(0f);
                    m_enemies[i].Move(-10f);
                }


                for (int j = 0; j < m_players.Count; j++) 
                {
                    if(playerinput == true) //偵測輸入的時候 所有敵人的位置 如果在攻擊範圍內就叫出玩家攻擊    但他如果馬上關掉就只打的到一個  需要全部都吃到傷害  才關掉  但這樣會變成開啟的時候所有都會瘋狂吃傷害而死掉
                    {
                        if (m_enemies[i].transform.position.x <= m_players[j].m_attackpoint)
                        {
                            
                            m_enemies[i].gethitback = true;
                            m_enemies[i].hiteffect = true;
                            m_players[j].HitEnemy(m_enemies[i]);

                        }
                        else
                        {
                            playerinput = false;
                        }
                        playerinput = false;
                    }



                    if (m_enemies[i].transform.position.x >= m_players[j].m_attackpoint + 2) //超出受擊後退範圍
                    {
                        m_enemies[i].gethitback = false;
                    }


                    if (m_enemies[i].transform.position.x <= m_players[j].transform.position.x)   //enemy hit player
                    {
                        m_enemies[i].HitPlayer(m_players[j]);
                        m_enemies[i].Die();

                    }


                    if (m_enemies.Count <= 0) //如果都死光會報錯:out of range  所以要return
                        return;


                }


            }
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