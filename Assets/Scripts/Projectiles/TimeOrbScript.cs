using UnityEngine;

public class TimeOrbScript : ProjectileScript
{
   [SerializeField] float timeUpgrade=10f;

    protected override void OnPlayerHit()
    {
        Debug.Log("Time Increased");
        gameManager.gameTime+=timeUpgrade;
        
        DestroyProjectile(playerHitClip);
    }
}
