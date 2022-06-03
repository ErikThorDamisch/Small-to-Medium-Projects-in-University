using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Head;
    public Animator Animator;
    public Transform AttackPosition;
    public Text DamageText;
    public GameObject blood;
    public GameObject MeleeWeapon;
    public GameObject tripleComboEffect;
    
    public float AttackRange;


    public AudioClip GotHit;
    public AudioClip Hit;
    public AudioClip Miss;
    public AudioClip trippleCombo;
    public AudioClip defense;

    public AudioSource sounds;

    public ParticleSystem SwordPS;
    

    [SerializeField]
    internal int DamageTaken;

    internal bool gotHit;

    [SerializeField]
    private float timeBetweenAttacks;
    private float StartTimeBetweenAttacksHeavy;
    private float StartTimeBetweenAttacksFast;
    private float startTimeBetweenDodges;
    private float dodgeTime;
    private float dazeFast;
    private float dazeHeavy;
    private float ForceToAddHeavy;
    private float ForceToAddFast;
    private float ForceMultiplier;
    private float hitEffectTimer;

    private bool player1;
    private bool player2;
    private bool player3;
    private bool player4;
    private bool attack1;
    private bool attack2;
    private bool dodge;

    private int comboHitFast;
    private int comboHitHeavy;
    private int layer;
    private int HeavyDamage;
    private int FastDamage;

    [SerializeField]
    private LayerMask Player;

    private GameObject Shield;

    

    private void Start()
    {
        sounds = GetComponent<AudioSource>();
        ForceMultiplier = 0;
        startTimeBetweenDodges = 0.5f;




        Shield = this.transform.Find("DodgeShield").gameObject;


        if (this.gameObject.tag == "Fast")
        {
            SetStats(0.3f, 0.5f, 0.3f, 0.5f, 200, 250, 1, 6, 10);
            Animator.SetFloat("UpperBodySpeed", 1.5f);
        }
        else if (this.gameObject.tag == "Medium")
        {
            SetStats(0.4f, 0.7f, 0.4f, 0.7f, 250, 300, 1, 9, 15);
            Animator.SetFloat("UpperBodySpeed", 1);
        }
        else if (this.gameObject.tag == "Slow")
        {
            SetStats(0.5f, 0.9f, 0.5f, 0.9f, 300, 350, 1, 12, 20);
            Animator.SetFloat("UpperBodySpeed", 0.75f);
        }

        if (this.gameObject.name == "Player1")
        {
            player1 = true;
            Player = LayerMask.GetMask("Player2", "Player3", "Player4");
            gameObject.layer = 9;
            layer = 9;
        }
        else if (this.gameObject.name == "Player2")
        {
            player2 = true;
            Player = LayerMask.GetMask("Player1", "Player3", "Player4");
            gameObject.layer = 10;
            layer = 10;
        }
        else if (this.gameObject.name == "Player3")
        {
            player3 = true;
            Player = LayerMask.GetMask("Player1", "Player2", "Player4");
            gameObject.layer = 11;
            layer = 11;
        }
        else if (this.gameObject.name == "Player4")
        {
            player4 = true;
            Player = LayerMask.GetMask("Player1", "Player2", "Player3");
            gameObject.layer = 12;
            layer = 12;
        }
    }

    void Update()
    {
        if (player1)
        {
            attack1 = Input.GetButtonDown("Fire1_1");
            attack2 = Input.GetButtonDown("Fire2_1");
            dodge = Input.GetButtonDown("Dodge1");
            Attack();
        }
        else if (player2)
        {
            attack1 = Input.GetButtonDown("Fire1_2");
            attack2 = Input.GetButtonDown("Fire2_2");
            dodge = Input.GetButtonDown("Dodge2");
            Attack();
        }
        else if (player3)
        {
            attack1 = Input.GetButtonDown("Fire1_3");
            attack2 = Input.GetButtonDown("Fire2_3");
            dodge = Input.GetButtonDown("Dodge3");
            Attack();
        }
        else if (player4)
        {
            attack1 = Input.GetButtonDown("Fire1_4");
            attack2 = Input.GetButtonDown("Fire2_4");
            dodge = Input.GetButtonDown("Dodge4");
            Attack();
        }


        if (gotHit)
        {
            Head.GetComponent<SpriteRenderer>().color = Color.red;
            hitEffectTimer -= Time.deltaTime;

            if (hitEffectTimer <= 0)
            {
                gotHit = false;
                if (this.tag == "Medium")
                {
                    Head.GetComponent<SpriteRenderer>().color = new Color32(12, 255, 0, 255);
                }
                else
                {
                    Head.GetComponent<SpriteRenderer>().color = new Color32(255, 190, 120, 255);
                }

                hitEffectTimer = 0.3f;

            }
        }


        if (timeBetweenAttacks >= 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }

        if (startTimeBetweenDodges >= 0)
        {
            startTimeBetweenDodges -= Time.deltaTime;
        }

        if (dodgeTime >= 0)
        {
            dodgeTime -= Time.deltaTime;
        }

        if (DamageTaken > 300)
        {
            DamageTaken = 300;
        }
        UpdateDamageText(DamageTaken);
    }
    private void UpdateDamageText(int damage)
    {
        DamageText.text = damage.ToString() + "%";
    }

    private void Attack()
    {
        if (comboHitFast == 1)
        {
            MeleeWeapon.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (comboHitFast == 2)
        {
            MeleeWeapon.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (comboHitFast == 0)
        {
            MeleeWeapon.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (comboHitHeavy == 1)
        {
            SwordPS.gameObject.SetActive(true);
            var main = SwordPS.main;
            main.startColor = main.startColor = Color.blue;
        }
        else if (comboHitHeavy == 2)
        {
            SwordPS.gameObject.SetActive(true);
            var main = SwordPS.main;
            main.startColor = main.startColor =  Color.red;
        }
        else if (comboHitHeavy == 0)
        {
            SwordPS.gameObject.SetActive(false);
        }

        if (timeBetweenAttacks <= 0 && !dodge)
        {
            if (attack1)
            {
                Animator.SetTrigger("Slash");
                DMGENEMY(HeavyDamage, dazeHeavy, StartTimeBetweenAttacksHeavy, "HEAVY");
            }
            else if (attack2)
            {
                Animator.SetTrigger("Jab");
                DMGENEMY(FastDamage, dazeFast, StartTimeBetweenAttacksFast, "FAST");
            }
            
        }

        if (dodge && startTimeBetweenDodges <= 0)
        {
            Animator.SetBool("Crouch", true);
            Shield.SetActive(true);
            gameObject.layer = 0;
            dodgeTime = 0.5f;
            timeBetweenAttacks += 0.5f;
            startTimeBetweenDodges = 0.5f;
            if (!sounds.isPlaying)
            {
                sounds.PlayOneShot(defense, PlayerPrefs.GetFloat("InGameVolumePreferences"));
            }
        }
        else if (dodgeTime <= 0)
        {
            gameObject.layer = layer;
            Animator.SetBool("Crouch", false);
            Shield.SetActive(false);
        }
    }

    private void DMGENEMY(int dmg, float daze, float startTime, string dmgtype)
    {
        Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, Player);

        if (enemyToDamage.Length >= 1)
        {
            if (dmgtype == "FAST")
            {
                comboHitFast += 1;
                if (!sounds.isPlaying)
                {
                    sounds.PlayOneShot(Hit, PlayerPrefs.GetFloat("InGameVolumePreferences"));
                }

            }
            else if (dmgtype == "HEAVY")
            {
                comboHitHeavy += 1;
                if (!sounds.isPlaying)
                {
                    sounds.PlayOneShot(Hit, PlayerPrefs.GetFloat("InGameVolumePreferences"));
                }
            }

        }
        else
        {
            if (!sounds.isPlaying)
            {
                sounds.PlayOneShot(Miss, PlayerPrefs.GetFloat("InGameVolumePreferences"));
            }
            
        }

        for (int i = 0; i < enemyToDamage.Length; i++)
        {
            if (!enemyToDamage[i].isTrigger)
            {
                if (!enemyToDamage[i].GetComponent<PlayerAttack>().sounds.isPlaying)
                {
                    enemyToDamage[i].GetComponent<PlayerAttack>().sounds.PlayOneShot(GotHit, PlayerPrefs.GetFloat("InGameVolumePreferences"));
                }
                enemyToDamage[i].GetComponent<PlayerAttack>().gotHit = true;
                int tempDMG = enemyToDamage[i].GetComponent<PlayerAttack>().DamageTaken += dmg;
                ForceMultiplier = 1 + (tempDMG / 100);
                enemyToDamage[i].GetComponent<PlayerAttack>().timeBetweenAttacks += daze;
                enemyToDamage[i].GetComponent<PlayerAttack>().comboHitFast = 0;
                enemyToDamage[i].GetComponent<PlayerAttack>().comboHitHeavy = 0;
                enemyToDamage[i].GetComponent<CharacterControl>().PauseMovement += (daze / 2);
                
                print(enemyToDamage[i].name + "got hit by" + this.name);

                if (enemyToDamage.Length >= 1)
                {
                    if (comboHitFast >= 3)
                    {
                        CalculateDirectionComboHit(enemyToDamage[i], ForceToAddFast, ForceMultiplier);
                        comboHitFast = 0;
                        enemyToDamage[i].GetComponent<PlayerAttack>().sounds.PlayOneShot(trippleCombo, PlayerPrefs.GetFloat("InGameVolumePreferences"));
                    }
                    else if (comboHitHeavy >= 3)
                    {
                        CalculateDirectionComboHit(enemyToDamage[i], ForceToAddHeavy, ForceMultiplier);
                        comboHitHeavy = 0;
                        enemyToDamage[i].GetComponent<PlayerAttack>().sounds.PlayOneShot(trippleCombo, PlayerPrefs.GetFloat("InGameVolumePreferences"));
                    }
                    else if (comboHitFast < 3 && comboHitHeavy < 3)
                    {
                        if (dmgtype == "FAST")
                        {
                            CalculateDirectionSingleHit(enemyToDamage[i], ForceToAddFast, ForceMultiplier);
                        }
                        else if (dmgtype == "HEAVY")
                        {
                            CalculateDirectionSingleHit(enemyToDamage[i], ForceToAddHeavy, ForceMultiplier);
                        }
                    }

                }

            }

            timeBetweenAttacks = startTime;
            Instantiate(blood, enemyToDamage[i].transform);
        }
    }

    private void CalculateDirectionComboHit(Collider2D collider, float forceToAdd, float forceMultiplier)
    {
        collider.gameObject.transform.Find("TripleComboEffect").GetComponent<ParticleSystem>().Clear();
        collider.gameObject.transform.Find("TripleComboEffect").GetComponent<ParticleSystem>().Play();
        collider.gameObject.GetComponent<CharacterControl>().isFlying = true;
        collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (this.gameObject.transform.localScale.x > 0)
        {
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceToAdd * forceMultiplier, forceToAdd * forceMultiplier));
        }
        else if (this.gameObject.transform.localScale.x <= 0)
        {
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(forceToAdd * forceMultiplier), forceToAdd * forceMultiplier));
        }
    }

    private void CalculateDirectionSingleHit(Collider2D collider, float forceToAdd, float forceMultiplier)
    {
        collider.gameObject.GetComponent<CharacterControl>().isFlying = true;
        collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (this.gameObject.transform.localScale.x > 0)
        {
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 200));
        }
        else if (this.gameObject.transform.localScale.x <= 0)
        {
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 200));
        }
    }

    private void SetStats(float startF, float startH, float dazeF, float dazeH, int forceF, int ForceH, float forceM, int dmgF, int dmgH)
    {
        StartTimeBetweenAttacksFast = startF;
        StartTimeBetweenAttacksHeavy = startH;
        dazeFast = dazeF;
        dazeHeavy = dazeH;
        ForceToAddFast = forceF;
        ForceToAddHeavy = ForceH;
        ForceMultiplier = forceM;
        FastDamage = dmgF;
        HeavyDamage = dmgH;
    }
}
