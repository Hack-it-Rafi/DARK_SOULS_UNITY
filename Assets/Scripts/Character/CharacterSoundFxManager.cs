using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterSoundFxManager : MonoBehaviour
    {
        protected AudioSource audioSource;

        protected virtual void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayRollSoundFx()
        {
            audioSource.PlayOneShot(WorldSoundFxManager.instance.rollSFX);
        }
        
    }
}
