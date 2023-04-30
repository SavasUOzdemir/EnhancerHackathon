using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    bool canCharge = true;

    private PlayerStats playerStats;
    private Rigidbody2D rb2d;
    private TransformationHandler transformationHandler;
    private SpriteRenderer sr;
    private OptionsCanvas optionsCanvas;
    Coroutine cooldownCoroutine;
    Coroutine weaponActiveTimer;
    Vector2 movement;
    int cooldownTimer = 2;
    float weaponTimer = 0.3f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>(includeInactive: false);
        optionsCanvas = FindObjectOfType<OptionsCanvas>(includeInactive: true);
        transformationHandler = GetComponent<TransformationHandler>();
        playerStats=gameObject.GetComponent<PlayerStats>();

    }

    private void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity = movement;
        }
        
    }

    IEnumerator WeaponActiveCooldown(float weapontimer)
    {
        transformationHandler.Weapon.SetActive(true);
        yield return new WaitForSeconds(weapontimer);
        switch (rb2d.mass)
        {
            case 1: playerStats.Speed=transformationHandler.SmolFishSpeed; break;
            case 2: playerStats.Speed = transformationHandler.DefaultFishSpeed; break;
            case 4: playerStats.Speed = transformationHandler.MidFishSpeed; break;
            case 12: playerStats.Speed = transformationHandler.LargeFishSpeed; break;
            default:break;
        }
        transformationHandler.Weapon.SetActive(false);
        StopCoroutine(weaponActiveTimer);

    }
    IEnumerator ChargeCooldown(int cooldowntimer)
    {
        yield return new WaitForSeconds(cooldowntimer);
        yield return canCharge = true;
        StopCoroutine(cooldownCoroutine);
    }
    private void Update()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move player
        movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        if (movement != Vector2.zero)
            transform.right = movement / moveSpeed;
        OrientSpriteRenderer();
        if (Input.GetKeyDown(KeyCode.Escape)) { optionsCanvas.gameObject.SetActive(!optionsCanvas.gameObject.activeSelf); }
        if (Input.GetKey(KeyCode.Space) && rb2d.mass == 12 && canCharge)
        {
            Debug.Log("buraya girdi");
            playerStats.Speed = 40;
            weaponActiveTimer = StartCoroutine(WeaponActiveCooldown(weaponTimer));
            canCharge = false;
            cooldownCoroutine = StartCoroutine(ChargeCooldown(cooldownTimer));
        }

    }

    void OrientSpriteRenderer()
    {
        if ((transform.rotation.eulerAngles.z >= 135 && transform.rotation.eulerAngles.z < 180) || (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z <= 225))
            sr.flipY = true;
        else sr.flipY = false;
    }
}

