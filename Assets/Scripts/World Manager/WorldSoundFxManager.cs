using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WorldSoundFxManager : MonoBehaviour
    {
        public static WorldSoundFxManager instance;

        [Header("Damage Sound Effects")]
        public AudioClip[] physicalDamageSFX;

        [Header("Action Sound Effects")]
        public AudioClip rollSFX;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public AudioClip ChooseRandomSFXFromArray(AudioClip[] array)
        {
            int index = Random.Range(0, array.Length);
            return array[index];
        }
        
    }
}
