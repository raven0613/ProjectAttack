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

        private void UnityEventSender_OnUnityUpdate()
        {
            for(int i = 0; i < m_players.Count; i++)
            {
                m_players[i].TickDebuger();
                m_players[i].DetectInput();
            }

            for (int i = 0; i < m_enemies.Count; i++)
            {
                m_enemies[i].Move(100f);
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