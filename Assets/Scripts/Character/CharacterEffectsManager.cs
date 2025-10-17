using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterEffectsManager : MonoBehaviour
    {
        //Process Instant Effects(Take Damage, Heal)

        //Process Time Duration Effects(Bleed, Poison build up)

        //Process Static Effects(Adding/Removing Buffs from Talismans)

        CharacterManager character;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }

        public virtual void ProcessInstantEffect(InstantCharacterEffect effect)
        {
            effect.ProcessEffect(character);
        }

    }
}
