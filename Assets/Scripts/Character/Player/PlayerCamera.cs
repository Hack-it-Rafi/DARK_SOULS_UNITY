using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
   public class PlayerCamera : MonoBehaviour
   {
      public static PlayerCamera instance;

      public Camera cameraObject;
      public PlayerManager player;
      [SerializeField] Transform cameraPivotTransform;

      [Header("Camera Settings")]
      private float cameraSmoothSpeed = 1f; //The lower the value, the faster the camera moves
      [SerializeField] float leftAndRightRotationSpeed = 480;
      [SerializeField] float upAndDownRotationSpeed = 400;
      [SerializeField] float maximumPivot = 60;
      [SerializeField] float minimumPivot = -30;
      [SerializeField] float cameraCollisionRadius = 0.2f;
      [SerializeField] LayerMask collideWithLayers; 

      [Header("Camera Values")]
      private Vector3 cameraVelocity;
      private Vector3 cameraObjectPosition; //Camera collision position
      [SerializeField] float leftAndRightLookAngle;
      [SerializeField] float upAndDownLookAngle;
      private float cameraZPosition;
      private float targetCameraZPosition;


      private void Awake()
      {
         if (instance == null)
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
         cameraZPosition = cameraObject.transform.localPosition.z;
      }

      public void HandleAllCameraActions()
      {
         if (player != null)
         {
            HandleFollowTarget();
            HandleRotations();
            HandleCollisions();
         }
      }

      private void HandleFollowTarget()
      {
         Vector3 targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
         transform.position = targetPosition;
      }

      private void HandleRotations()
      {
         leftAndRightLookAngle += (PlayerInputManager.instance.cameraHorizontalInput * leftAndRightRotationSpeed) * Time.deltaTime;
         upAndDownLookAngle -= (PlayerInputManager.instance.cameraVerticalInput * upAndDownRotationSpeed) * Time.deltaTime;

         upAndDownLookAngle = Mathf.Clamp(upAndDownLookAngle, minimumPivot, maximumPivot);

         Vector3 cameraRotation = Vector3.zero;
         Quaternion targetRotation;


         // cameraRotation.x = upAndDownLookAngle;
         cameraRotation.y = leftAndRightLookAngle;

         targetRotation = Quaternion.Euler(cameraRotation);
         transform.rotation = targetRotation;

         cameraRotation = Vector3.zero;
         cameraRotation.x = upAndDownLookAngle;
         // cameraRotation.y = leftAndRightLookAngle;

         targetRotation = Quaternion.Euler(cameraRotation);

         cameraPivotTransform.localRotation = targetRotation;

      }

      private void HandleCollisions()
      {
         targetCameraZPosition = cameraZPosition;
         RaycastHit hit;
         Vector3 direction = cameraObject.transform.position - cameraPivotTransform.position;
         direction.Normalize();

         if (Physics.SphereCast(cameraPivotTransform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetCameraZPosition), collideWithLayers))
         {
            float distanceFromObject = Vector3.Distance(cameraPivotTransform.position, hit.point);
            targetCameraZPosition = -(distanceFromObject - cameraCollisionRadius);
         }

         if (Mathf.Abs(targetCameraZPosition) < cameraCollisionRadius)
         {
            targetCameraZPosition = -cameraCollisionRadius;
         }

         cameraObjectPosition.z = Mathf.Lerp(cameraObject.transform.localPosition.z, targetCameraZPosition, 0.2f);
         cameraObject.transform.localPosition = cameraObjectPosition;
      }

   }
}
