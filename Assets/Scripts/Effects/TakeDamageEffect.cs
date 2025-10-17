using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "Character Effects/Instant Effects/Take Damage")]
    public class TakeDamageEffect : InstantCharacterEffect
    {
        [Header("Character Causing Damage")]
        public CharacterManager characterCausingDamage;

        [Header("Damage")]
        public float physicalDamage = 0; //(Standard, Strike, Slash, Pierce Damage)
        public float magicDamage = 0;
        public float fireDamage = 0;
        public float lightningDamage = 0;
        public float holyDamage = 0;

        [Header("Final Damage")]
        private int finalDamageDealt = 0;

        [Header("Poise")]
        public float poiseDamage = 0;
        public bool poiseIsBroken = false;

        [Header("Animation")]
        public bool playDamageAnimation = true;
        public bool manuallySelectDamageAnimation = false;
        public string damageAnimation;

        [Header("Sound")]
        public bool willPlayDamageSFX = true;
        public AudioClip elementalDamageSFX; //USED ON TOP OF THE DEFAULT DAMAGE SFX IF THERE IS ELEMENTAL DAMAGE

        [Header("Direction Damage Taken From")]
        public float angleHitFrom; //USED TO DETERMINE IF DAMAGE IS BEING TAKEN FROM FRONT OR BACK OR LEFT OR RIGHT
        public Vector3 contactPoint; //USED TO DETERMINE WHERE THE BLOOD FX WILL BE APPLIED


        public override void ProcessEffect(CharacterManager character)
        {
            base.ProcessEffect(character);

            if (character.isDead.Value)
                return;

            CalculateDamage(character);
        }

        private void CalculateDamage(CharacterManager character)
        {
            if (!character.IsOwner)
                return;


            if (characterCausingDamage != null)
            {

            }

            finalDamageDealt = Mathf.RoundToInt(physicalDamage + magicDamage + fireDamage + lightningDamage + holyDamage);

            if (finalDamageDealt <= 0)
            {
                finalDamageDealt = 1;
            }

            Debug.Log($"Final Damage Dealt:"+ finalDamageDealt);

            character.characterNetworkManager.currentHealth.Value -= finalDamageDealt;
        }

    }
}