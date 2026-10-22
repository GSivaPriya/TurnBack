using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{  
   
    protected GameManager gameManager;
    protected PlayerController player;
    [SerializeField] public AudioClip playerHitClip;
    [SerializeField] AudioClip AstroidHitClip;
    [SerializeField] public float mspeed;
    [SerializeField] bool isAffectedByShield;
    float lifeTime=7f;
    Transform centre;
    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centre = GameObject.Find("Centre").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player")
                                         .GetComponent<PlayerController>();

        direction = (centre.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction*mspeed*Time.deltaTime);
        lifeTime-=Time.deltaTime;
        if(lifeTime<=0.01f)
        {
            DestroySelf();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnPlayerHit();
        }
        if(collision.gameObject.CompareTag("ERed"))
        {
           DestroyProjectile(AstroidHitClip);
        }
    }

    protected virtual void OnPlayerHit(){}
    public void DestroyProjectile(AudioClip clip)
    {
        AudioManager.PlaySFXRequested?.Invoke(clip);
        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
