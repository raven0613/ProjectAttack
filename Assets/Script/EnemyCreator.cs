using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectAttack
{
    public class EnemyCreator : MonoBehaviour
    {
        public GameObject EnemyPrefab;

        public float CreateTimer;
        public float CreateCDtime;

        private void Awake()
        {
            CreateCDtime = Random.Range(0.2f, 2);
        }
        void Update()
        {
            CreateTimer = CreateTimer + Time.deltaTime;
            EnemyCreate();
        }

        private void EnemyCreate()
        {
            if(CreateTimer >= CreateCDtime)
            {
                GameObject _Clone = Instantiate(EnemyPrefab);
                _Clone.transform.position = gameObject.transform.position;

                CreateTimer = 0;
                CreateCDtime = Random.Range(0.2f, 2);
            }

        }
    }


}
