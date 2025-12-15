using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace SG
{
    public class CharacterAnimatorManager : MonoBehaviour
    {
        CharacterManager character;
        int vertical;
        int horizontal;

        [Header("Damage Animations")]
        public string LastDamageAnimationPlayed;
        [SerializeField] string hit_Forward_Medium_01 = "Hit_Forward_Medium_01";
        [SerializeField] string hit_Forward_Medium_02 = "Hit_Forward_Medium_02";
        [SerializeField] string hit_Backward_Medium_01 = "Hit_Backward_Medium_01";
        [SerializeField] string hit_Backward_Medium_02 = "Hit_Backward_Medium_02";
        [SerializeField] string hit_Left_Medium_01 = "Hit_Left_Medium_01";
        [SerializeField] string hit_Left_Medium_02 = "Hit_Left_Medium_02";
        [SerializeField] string hit_Right_Medium_01 = "Hit_Right_Medium_01";
        [SerializeField] string hit_Right_Medium_02 = "Hit_Right_Medium_02";

        public List<string> forward_Medium_Damage = new List<string>();
        public List<string> backward_Medium_Damage = new List<string>();
        public List<string> left_Medium_Damage = new List<string>();
        public List<string> right_Medium_Damage = new List<string>();

        protected virtual void Start()
        {
            forward_Medium_Damage.Add(hit_Forward_Medium_01);
            forward_Medium_Damage.Add(hit_Forward_Medium_02);

            backward_Medium_Damage.Add(hit_Backward_Medium_01);
            backward_Medium_Damage.Add(hit_Backward_Medium_02);
            
            left_Medium_Damage.Add(hit_Left_Medium_01);
            left_Medium_Damage.Add(hit_Left_Medium_02);

            right_Medium_Damage.Add(hit_Right_Medium_01);
            right_Medium_Damage.Add(hit_Right_Medium_02);
        }

        public string GetRandomAnimationFromList(List<string> animationList)
        {
            List<string> finalList = new List<string>();

            foreach (var item in animationList)
            {
                finalList.Add(item);
            }

            finalList.Remove(LastDamageAnimationPlayed);

            for (int i = finalList.Count-1; i >-1; i--)
            {
                if(finalList[i] == null)
                {
                    finalList.RemoveAt(i);
                }
            }

            int randomIndex = Random.Range(0, finalList.Count);
            return finalList[randomIndex];
        }

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();

            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }


        public void UpdateAnimatorMovementParameters(float horizontalMovement, float verticalMovement, bool isSprinting)
        {
            float horizontalAmount = horizontalMovement;
            float verticalAmount = verticalMovement;

            if (isSprinting)
            {
                verticalAmount = 2;
            }
            //OPTION 01
            character.animator.SetFloat(horizontal, horizontalAmount, 0.1f, Time.deltaTime);
            character.animator.SetFloat(vertical, verticalAmount, 0.1f, Time.deltaTime);

            //OPTION 02
            // if(horizontalMovement > 0 && horizontalMovement <= 0.55f)
            // {
            //     snappedHorizontal = 0.5f;
            // }
            // else if(horizontalMovement > 0.5f && horizontalMovement <= 1f)
            // {
            //     snappedHorizontal = 1;
            // }
            // else if(horizontalMovement < 0 && horizontalMovement >= -0.5f)
            // {
            //     snappedHorizontal = -0.5f;
            // }
            // else if(horizontalMovement < -0.5f && horizontalMovement >= -1f)
            // {
            //     snappedHorizontal = -1;
            // }
            // else
            // {
            //     snappedHorizontal = 0;
            // }


            // if(verticalMovement > 0 && verticalMovement <= 0.5f)
            // {
            //     snappedVertical = 0.5f;
            // }
            // else if(verticalMovement > 0.5f && verticalMovement <= 1f)
            // {
            //     snappedVertical = 1;
            // }
            // else if(verticalMovement < 0 && verticalMovement >= -0.5f)
            // {
            //     snappedVertical = -0.5f;
            // }
            // else if(verticalMovement < -0.5f && verticalMovement >= -1f)
            // {
            //     snappedVertical = -1;
            // }
            // else
            // {
            //     snappedVertical = 0;
            // }

            // character.animator.SetFloat("Horizontal", snappedHorizontal);
            // character.animator.SetFloat("Vertical", snappedVertical);



        }

        public virtual void PlayTargetActionAnimation(string targetAnimation, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
        {
            if (targetAnimation == "Swap_Right_Weapon_01")
            {
                Debug.Log("Swap_Right_Weapon_01 animation ");
            }
            Debug.Log("Playing Animation: " + targetAnimation);
            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);
            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;

            character.characterNetworkManager.NotifyTheServerOfAttackActionAnimationServerRpc(NetworkManager.Singleton.LocalClientId, targetAnimation, applyRootMotion);

        }

        public virtual void PlayTargetAttackActionAnimation(AttackType attackType, string targetAnimation, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
        {
            if (targetAnimation == "Swap_Right_Weapon_01")
            {
                Debug.Log("Swap_Right_Weapon_01 animation ");
            }
            character.characterCombatManager.currentAttackType = attackType;
            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);
            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;

            character.characterNetworkManager.NotifyTheServerOfAttackActionAnimationServerRpc(NetworkManager.Singleton.LocalClientId, targetAnimation, applyRootMotion);

        }
    }
}
