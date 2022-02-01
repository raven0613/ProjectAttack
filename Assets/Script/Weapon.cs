using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAttack
{
    public class Weapon : MonoBehaviour
    {
        public float WeaponRotateSpeed;
        public float WeaponRotatePosition;
        public float percentage;

        public bool WeaponStartRotate;
        public bool hitcheck;


        public float WeaponTimetoStop = 1f;
        public float WeaponTimetoStopTimer;


        Vector3 WeaponStartPosition;

        private void Awake()
        {
            WeaponRotateSpeed = 800;
            WeaponStartPosition = gameObject.transform.position;
            percentage = 1f;
            hitcheck = false;
        }

        public void StartRotate()
        {

            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.position = WeaponStartPosition;

            WeaponStartRotate = true;
        }
        public void AttackRating()
        {
            hitcheck = true;
        }

        private void Rotate()
        {
            gameObject.transform.Rotate(0, 0, WeaponRotatePosition );
            gameObject.transform.position = gameObject.transform.position + Vector3.right * Time.deltaTime * 0.5f * percentage;
            gameObject.transform.position = gameObject.transform.position + Vector3.down * Time.deltaTime * 0.5f * percentage;
        }

        void Update() //遇到第一隻進來的時候hitcheck沒有打開  都後退了才打開有個毛用
        { 
            if (WeaponStartRotate == true)
            {


                WeaponTimetoStop = 0.15f;
                WeaponTimetoStopTimer = WeaponTimetoStopTimer + Time.deltaTime;
                WeaponRotatePosition = 0;
                WeaponRotatePosition = WeaponRotatePosition - 1 * WeaponRotateSpeed * Time.deltaTime * percentage;

                Rotate();

                if(hitcheck == true) //讓這個給戰鬥管理器???
                {
                    WeaponTimetoStop = 0.28f;
                    if (WeaponTimetoStopTimer >= 0.05f && WeaponTimetoStopTimer <= 0.2f)
                    {
                        percentage = 0.01f;
                    }
                    if (WeaponTimetoStopTimer > 0.2f && WeaponTimetoStopTimer < WeaponTimetoStop)
                    {
                        percentage = 1f;
                        
                    }

                }
                

                if (WeaponTimetoStopTimer >= WeaponTimetoStop)
                {
                    hitcheck = false;
                    WeaponStartRotate = false;
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    gameObject.transform.position = WeaponStartPosition;
                    WeaponTimetoStopTimer = 0;
                    
                }
            }
        }
    }
}
