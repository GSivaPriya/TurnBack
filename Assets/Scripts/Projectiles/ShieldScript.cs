using UnityEngine;

public class ShieldScript : ProjectileScript
{
    [SerializeField] float shieldDuration=5f;
    protected override void OnPlayerHit()
    {
        Debug.Log("ShieldActive");
        player.ActivateShield(shieldDuration);
        
        DestroyProjectile(playerHitClip);
    }
}
