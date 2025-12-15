using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class Utility_DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] float timeUntilDestroyed = 5f;

        void Awake()
        {
            Destroy(gameObject, timeUntilDestroyed);
        }
    }
}