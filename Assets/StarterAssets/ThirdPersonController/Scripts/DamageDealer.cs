using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f; // Damage per attack
    [SerializeField] private string enemyTag = "Enemy"; // Tag to identify enemies
    private bool canDealDamage = false; // Tracks if the attack can deal damage
    private bool hasDealtDamage = false; // Prevents multiple damage in one attack

    // Called by SamuraiController or Animation Event to enable damage
    public void EnableDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false; // Reset for the new attack
    }

    // Called by SamuraiController or Animation Event to disable damage
    public void DisableDamage()
    {
        canDealDamage = false;
        hasDealtDamage = false; // Reset for next attack
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if we can deal damage, haven't already, and the target is an enemy
        if (canDealDamage && !hasDealtDamage && other.CompareTag(enemyTag))
        {
            // Try to get a health component (you'll need to create this)
            if (other.TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(damageAmount);
                hasDealtDamage = true; // Prevent further damage this attack
                Debug.Log($"Dealt {damageAmount} damage to {other.name}");
            }
        }
    }
}