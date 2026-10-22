using UnityEngine;

public class ScoreProjectiles : ProjectileScript
{
    [SerializeField] float points;

    protected override void OnPlayerHit()
    {
        gameManager.UpdateScore(points);
        Debug.Log($"Score:{points}");
        DestroyProjectile(playerHitClip);
    }
}
