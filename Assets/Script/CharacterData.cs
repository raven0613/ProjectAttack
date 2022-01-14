using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ProjectAttack
{
    // JsonFx
    // json file => JsonFx => CharacterData
    public class CharacterData 
    {
        public int Attack { get; private set; }
        public int HP { get; private set; }
        public float MoveSpeed { get; private set; }
        public float AttackRange { get; private set; }

        public CharacterData() { }

        public static CharacterData GetTestData()
        {
            return new CharacterData
            {
                Attack = 10,
                HP = 10,
                MoveSpeed = 10,
                AttackRange = 2.5f
            };
        }
    }
}