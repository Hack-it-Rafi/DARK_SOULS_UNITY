using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WeaponItem : Item
    {
        // Animator Controller Override(Change attack animations based on weapon)
        [Header("Weapon Model")]
        public GameObject weaponModel;

        [Header("Weapon Requirements")]
        public int strengthREQ = 0;
        public int dexREQ = 0;
        public int intREQ = 0;
        public int faithREQ = 0;

        [Header("Weapon Based Damage")]
        public int physicalDamage = 0;
        public int magicDamage = 0;
        public int fireDamage = 0;
        public int lightningDamage = 0;
        public int holyDamage = 0;

        [Header("Weapon Based Poise Damage")]
        public float poiseDamage = 10f;

        //Weapon Modifiers
        //Light Attack Modifier
        //Heavy Attack Modifier
        //Critical Attack Modifier

        [Header("Stamina Cost")]
        public int baseStaminaCost = 20;


        [Header("Actions")]
        public WeaponItemAction oh_RB_Action;  // One Handed Right Bumper Action
    }
}
