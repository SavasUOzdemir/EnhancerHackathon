using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationHandler : MonoBehaviour
{
    bool canTransformNow = false;
    public bool CanTransformNow { get => canTransformNow; set => canTransformNow = value; }

    bool transformOneEnabled = false;
    bool transformTwoEnabled = false;
    bool transformThreeEnabled = false;

    [SerializeField] float defaultSpeed;
    [SerializeField] float smolFishSpeed;
    [SerializeField] float midFishSpeed;
    [SerializeField] float largeFishSpeed;

    [SerializeField] GameObject smallCollider;
    [SerializeField] GameObject largeCollider;
    [SerializeField] GameObject midCollider;
    [SerializeField] GameObject defaultCollider;
    GameObject weapon;

    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;
    PlayerStats playerStats;
    [SerializeField] int[] rbMasses = new int[4];
    public bool TransformOneEnabled { get => transformOneEnabled; set => transformOneEnabled = value; }
    public bool TransformTwoEnabled { get => transformTwoEnabled; set => transformTwoEnabled = value; }
    public bool TransformThreeEnabled { get => transformThreeEnabled; set => transformThreeEnabled = value; }
    public GameObject Weapon { get => weapon; }
    Rigidbody2D rb2D;
    public delegate void TransformationStartedDelegate();
    public event TransformationStartedDelegate TransformationStarted;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        weapon=GetComponentInChildren<Weapon>(includeInactive:true).gameObject;

    }

    void TransformCharacter(int transformNumber)
    {
        ResetToDefault();
        if (transformNumber == 0) Debug.Log("nothing to see here");
        else if (transformNumber == 1)
        {
            capsuleCollider.size = smallCollider.GetComponent<CapsuleCollider2D>().size;
            playerStats.Speed = smolFishSpeed;
            TransformationStarted();
        }
        else if (transformNumber == 2)
        {
            capsuleCollider.size = midCollider.GetComponent<CapsuleCollider2D>().size;
            playerStats.DamageReduction = 2;
            playerStats.Speed = midFishSpeed;
            TransformationStarted();
        }
        else if (transformNumber == 3)
        {
            capsuleCollider.size = largeCollider.GetComponent<CapsuleCollider2D>().size;
            playerStats.Speed = largeFishSpeed;
            Weapon.GetComponent<CapsuleCollider2D>().offset = new Vector2(5, 0);
            Weapon.SetActive(true);
            TransformationStarted();
        }
        else
        {
            Debug.Log("invalid transformation value passed by transformer");
            return;
        }
        spriteRenderer.sprite = spriteRenderer.gameObject.GetComponent<CharacterSprites>().sprites[transformNumber];
        rb2D.mass = rbMasses[transformNumber];
    }

    void ResetToDefault()
    {
        capsuleCollider.size = defaultCollider.GetComponent<CapsuleCollider2D>().size;
        playerStats.DamageReduction = 1;
        Weapon.SetActive(false);
        playerStats.Speed = defaultSpeed;
    }
}
