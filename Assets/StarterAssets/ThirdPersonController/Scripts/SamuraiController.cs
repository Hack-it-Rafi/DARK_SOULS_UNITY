using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

[RequireComponent(typeof(Animator))]
public class SamuraiController : MonoBehaviour
{
    // Components
    private Animator animator;
    private PlayerInput playerInput;
    public ThirdPersonController thirdPersonController;
    [SerializeField] private DamageDealer katanaDamageDealer; // Reference to DamageDealer

    // Combat Variables
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float comboWindow = 0.8f;
    private float lastAttackTime;
    private int comboCount = 0;
    private bool isAttacking = false;

    // Animation hashes
    private readonly int attack1Hash = Animator.StringToHash("Attack1");
    private readonly int attack2Hash = Animator.StringToHash("Attack2");
    private readonly int attack3Hash = Animator.StringToHash("Attack3");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        HandleCombat();
    }

    private void HandleCombat()
    {
        // Reset combo if combo window expires
        if (isAttacking && Time.time >= lastAttackTime + comboWindow)
        {
            ResetCombo();
        }
    }

    private void StartCombo()
    {
        comboCount = 1;
        isAttacking = true;
        animator.SetTrigger(attack1Hash);
        lastAttackTime = Time.time;

        // Enable damage and lock movement
        if (katanaDamageDealer != null)
        {
            katanaDamageDealer.EnableDamage();
        }
        if (thirdPersonController != null)
        {
            thirdPersonController.SetAttackState(true);
        }
    }

    private void ContinueCombo()
    {
        if (comboCount == 1)
        {
            comboCount = 2;
            animator.SetTrigger(attack2Hash);
            lastAttackTime = Time.time;
        }
        else if (comboCount == 2)
        {
            comboCount = 3;
            animator.SetTrigger(attack3Hash);
            lastAttackTime = Time.time;
        }

        // Enable damage and keep movement locked
        if (katanaDamageDealer != null)
        {
            katanaDamageDealer.EnableDamage();
        }
        if (thirdPersonController != null)
        {
            thirdPersonController.SetAttackState(true);
        }
    }

    private void ResetCombo()
    {
        isAttacking = false;
        comboCount = 0;

        // Disable damage and unlock movement
        if (katanaDamageDealer != null)
        {
            katanaDamageDealer.DisableDamage();
        }
        if (thirdPersonController != null)
        {
            thirdPersonController.SetAttackState(false);
        }
    }

    // Called at the end of attack animations through Animation Events
    public void OnAttackAnimationEnd()
    {
        // Reset combo unless a new attack input is received
        ResetCombo();
    }

    // Called when the weapon "hits" something (optional)
    public void OnAttackHit()
    {
        Debug.Log("Attack hit!");
    }

    // Called by InputSystem
    public void OnAttack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
        {
            return; // Ignore input if still in cooldown
        }

        if (!isAttacking)
        {
            // Start a new combo if not attacking
            StartCombo();
        }
        else if (Time.time >= lastAttackTime + 0.2f)
        {
            // Continue combo if within combo window and after a short delay
            ContinueCombo();
        }
    }
}