using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Weapon : MonoBehaviour
    {
        public float WeaponRotateSpeed;
        public float WeaponRotatePosition;

        public bool WeaponStartRotate;

        public float WeaponTimetoStop = 1f;
        public float WeaponTimetoStopTimer;

        Vector3 WeaponStartPosition;

        private void Awake()
        {
            WeaponRotateSpeed = 1000;
            WeaponStartPosition = gameObject.transform.position;
        }


        void Update()
        {
            

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {

                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                WeaponStartRotate = true;

                
            }

            if(WeaponStartRotate == true)
            {
                WeaponRotatePosition = 0;
                WeaponRotatePosition = WeaponRotatePosition - 1 * WeaponRotateSpeed * Time.deltaTime;

                gameObject.transform.Rotate(0, 0, WeaponRotatePosition);
                gameObject.transform.position = gameObject.transform.position + Vector3.right * Time.deltaTime * 3;
                gameObject.transform.position = gameObject.transform.position + Vector3.down * Time.deltaTime * 3;

                WeaponTimetoStopTimer = WeaponTimetoStopTimer + Time.deltaTime;

                if (WeaponTimetoStopTimer >= WeaponTimetoStop)
                {
                    WeaponStartRotate = false;
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    gameObject.transform.position = WeaponStartPosition;
                    WeaponTimetoStopTimer = 0;
                }
            }


        }
    }
}
