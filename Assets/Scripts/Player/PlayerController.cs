using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] PlayerInputScript playerInputScript;
    [SerializeField] Transform centre;
    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] GameObject shieldParticles;
    public bool isShieldActive=false;
    float angle;

    void OnEnable()
    {
        playerInputScript.ReversePressed += ReverseDirection;
    }
    void OnDisable()
    {
        playerInputScript.ReversePressed -=ReverseDirection;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
        shieldParticles.SetActive(isShieldActive);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameOver)
        Move();
        shieldParticles.SetActive(isShieldActive);
    }

    void Move()
    {
        angle += speed*Time.deltaTime;

        float x = Mathf.Cos(angle)*radius;
        float y = Mathf.Sin(angle)*radius;

        transform.position = new Vector2(centre.position.x + x , centre.position.y + y);
    }

    void ReverseDirection()
    {
        //Debug.Log("PLAYER: Input Received");
        speed*=-1;
    }

    public void ActivateShield(float duration)
    {
        Debug.Log("Shield Active");
        StartCoroutine(ShieldRoutine(duration));
    }

    IEnumerator ShieldRoutine(float duration)
    {
        isShieldActive=true;

        yield return new WaitForSeconds(duration);
        Debug.Log("Shield Deactivating");
        isShieldActive=false;
    }
}