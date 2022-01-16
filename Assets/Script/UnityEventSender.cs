using UnityEngine;

namespace ProjectAttack
{
    public class UnityEventSender : MonoBehaviour
    {
        private static UnityEventSender m_instance;

        public static event System.Action OnUnityUpdate;

        private void Awake()
        {
            if(m_instance != null)
            {
                Destroy(this);
                return;
            }

            m_instance = this;
        }

        private void Update()
        {
            OnUnityUpdate?.Invoke();
        }
    }
}