using UnityEngine;

public class AstroidScript : ProjectileScript
{
    [SerializeField] float points=-10f;
    protected override void OnPlayerHit()
    {
        if(!player.isShieldActive)
        {
            gameManager.UpdateScore(points);
            Debug.Log("Damage Taken");
        }

        DestroyProjectile(playerHitClip);
    }
}
