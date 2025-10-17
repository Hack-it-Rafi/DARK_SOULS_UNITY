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

            if(isSprinting)
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
            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);

            //Can be used to disable the animator component
            //for example, when player get damaged, and begin to play the animation
            //we can disable the animator component to prevent the player from moving
            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;

            character.characterNetworkManager.NotifyTheServerOfActionAnimationServerRpc(NetworkManager.Singleton.LocalClientId, targetAnimation, applyRootMotion);

        }
    }
}
