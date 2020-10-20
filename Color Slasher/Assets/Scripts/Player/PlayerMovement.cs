using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ParticleSystem))]
public class PlayerMovement : MonoBehaviour, IObserverColor
{
    //  Force applied to the slash movement | 
    //  Friction applied to the slash (contrary to DirectionSwipe) | 
    //  Seconds the character remains without falling when touches a platform.
    [SerializeField] float forceSlash = 10f, frictionSlash = 1f, secondsGrab = 3f;
    [SerializeField] bool canSwipe;
    public int damage = 3;

    //  Debug variables. Code works with Properties.
    [SerializeField] bool onFloor, falling, doubleSwipe;
    [SerializeField] Dissolver diss;

    Animator anim;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Vector3 startPos, finalPos;
    ParticleSystem particleSlash;

    public static Action<string> InDeactivatePower;
    public static Action InEnemyKilled;

    AudioSource mySource;
    UISoundSystem mySoundSystem;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        particleSlash = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        

        DirectionSlash = Vector2.zero;

        IsDead = false;
        IsStill = false;
        DoubleSwipe = false;
        circleCollider.enabled = false;

        IsFalling = true;
        IsGrounded = true;

        mySource = gameObject.GetComponent<AudioSource>();
        mySoundSystem = gameObject.GetComponent<UISoundSystem>();

        PlayerLife.InCharacterDied -= TriggerDead;

        PlayerLife.InCharacterDied += TriggerDead;

        DeactivatePower();
    }

    void Update()
    {
        //  Gets the position where the screen is first touched.
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attacking");
            startPos = Input.mousePosition;
        }

        //  Let the character slash if IsGrounded (or gets the DoubleSwipe bonus) and not IsDead.
        if ((Input.GetButtonUp("Fire1")) &&
        (IsGrounded || DoubleSwipe) &&
        !IsDead)
        {
            diss.IsDissolving = true;
            //  Gets the position where the screen is last touched.
            finalPos = Input.mousePosition;
            //  Calculate the distance between x and y components, then traduces it to values from 0 to 1. 
            Vector3 v = Vector3.Normalize(finalPos - startPos);
            //  Crops the Vector3 to Vector2
            DirectionSlash = new Vector2(v.x, v.y);

            //  Checks if the character IsStill...
            if (IsStill)
            {
                //  if so, must slash upwards.
                if (DirectionSlash.y > 0) Slash();
            }
            //  if not, slash anyway.
            else Slash();
        }
    }

    void FixedUpdate()
    {
        //  Toggles the gravity depending on wheater the character IsFalling.
        rb.gravityScale = (IsFalling) ? 1 : ActivateFriction();
    }

    void Slash()
    {
        //  Starts the slash without any other force.
        rb.velocity = Vector2.zero;
        if (!IsGrounded) InDeactivatePower("Floor");
        IsGrounded = false;
        IsStill = false;
        IsFalling = false;

        //  Impulses this object in slash's direction.
        rb.AddForce(DirectionSlash * forceSlash, ForceMode2D.Impulse);

        //  Activate particle system.
        PlayParticlesSlash();
        //Play Hit Audio
        mySoundSystem.Action();
        //  ***Debug.Log(DirectionSlash);
    }

    int ActivateFriction()
    {
        //  Friction will be applied when character not IsGrounded.
        if (!IsGrounded)
        {
            //  Applies a force contrary to DirectionSlash's direction.
            rb.AddForce(-DirectionSlash * (forceSlash * frictionSlash), ForceMode2D.Force);

            //  If the character loses all it's upping energy, start to fall.
            if (rb.velocity.y <= 0) IsFalling = true;
        }

        return 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        diss.IsDissolving = false;
        //  Play Collision Audio
        mySoundSystem.Action2();

        //  When touching a platform restart the Grab counter.
        StopAllCoroutines();
        particleSlash.Stop();

        //  Check if the platform touched is floor.
        if (collision.contacts[0].normal == Vector2.up) IsStill = true;

        //  Whenever touches a paltform stops and can slash again.
        rb.velocity = Vector2.zero;
        IsGrounded = true;
        IsFalling = false;
        anim.SetTrigger("Landing");
        //  Activates Grab if the character not IsStill.
        if (!IsStill) StartCoroutine(Grab());
    }

    //  When touches a platform doesn't fall de inmediaty.
    IEnumerator Grab()
    {
        // Waits certain time to fall.
        yield return new WaitForSeconds(secondsGrab);

        IsFalling = true;

        //  vvv Uncomment this line to make Slash unable once Grab ends. vvv
        //IsGrounded = false;
    }

    void PlayParticlesSlash()
    {
        //  Calculate de arccos from negative X to get the angle and convert the result from radians to degrees.
        float angleInRad = Mathf.Acos(-DirectionSlash.x) * Mathf.Rad2Deg;

        //  Set te sense of the slash based on Y's value.
        particleSlash.gameObject.transform.rotation = Quaternion.Euler((DirectionSlash.y < 0) ? -angleInRad : angleInRad,
        90, 0);

        particleSlash.Play();
    }

    void TriggerDead(int i)
    {
        IsDead = true;
    }

    public bool IsGrounded { get => canSwipe; set => canSwipe = value; }
    public bool DoubleSwipe { get => doubleSwipe; set => doubleSwipe = value; }
    public bool IsStill { get => onFloor; set => onFloor = value; }
    public bool IsFalling { get => falling; set => falling = value; }
    public bool IsDead { get; set; }
    Vector2 DirectionSlash { get; set; }

    public void ColorMechUpdate(ColorMech colorMech)
    {
        switch (colorMech)
        {
            case ColorMech.blue:
                ActivateBluePower();
                break;

            case ColorMech.red:
                Invoke("ActivateRedPower", 2f);
                break;

            case ColorMech.yellow:
                ActivateYellowPower();
                break;

            case ColorMech.white:
                DeactivatePower();
                break;
        }
    }

    public void ActivateBluePower()
    {
        DoubleSwipe = true;
    }
    public void ActivateYellowPower()
    {
        forceSlash = 40;
    }
    void ActivateRedPower()
    {
        circleCollider.enabled = true;
    }

    public void DeactivatePower()
    {
        DoubleSwipe = false;
        forceSlash = 15;
        circleCollider.enabled = false;
    }
}