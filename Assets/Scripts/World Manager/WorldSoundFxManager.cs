using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WorldSoundFxManager : MonoBehaviour
    {
        public static WorldSoundFxManager instance;

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
        
        
    }
}
