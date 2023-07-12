using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeCtroller : MonoBehaviour
{
    private int groundMask = 1 << 8;
    private Vector2 physicsVelocity = Vector2.zero;
    private Vector2 colliderOffset;
    private Vector2 colliderSize;
    private Animator moving;
    private SpriteRenderer sprite;
    private Rigidbody2D r;
    private float dirX;
    private bool oppositeJump = false;
    private enum MovementState {stand, jump, move }
    private CapsuleCollider2D slime;
    [SerializeField]private float moveSpeed = 2.5f;
    [SerializeField] private float jumpHeight = 4.5f;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource MoveSound;
    [SerializeField] private AnimatorOverrideController WhiteSlime;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
        moving = GetComponent<Animator>();
        slime = GetComponent<CapsuleCollider2D>();
        colliderOffset = new Vector2(-0.002335342f, -0.2654035f);
        colliderSize = new Vector2(0.6763194f, 0.469961f);
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        r.velocity = new Vector2(dirX * moveSpeed, r.velocity.y);
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.move;
            MoveSound.Play();
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.move;
            MoveSound.Play();
            sprite.flipX = true;
        }
        else {
            state = MovementState.stand;
        }
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && checkTerance())
        {
            
            if (oppositeJump) {
                JumpSound.Play();
                r.velocity = new Vector2(physicsVelocity.x, -jumpHeight);
            }
            else
            {
                JumpSound.Play();
                r.velocity = new Vector2(physicsVelocity.x, jumpHeight);
            }
                
        }

        

        if (r.velocity.y > 0.5f || r.velocity.y < -0.5f) {
            state = MovementState.jump;
        }
        moving.SetInteger("state", (int)state);
    }

    private bool checkTerance() {
        return Physics2D.BoxCast(slime.bounds.center, slime.bounds.size, 0f, Vector2.down, .1f, groundMask);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Upsidedown")) {
            r.gravityScale = -3f;
            slime.offset = colliderOffset;
            slime.size = colliderSize;
        }

        if (collision.gameObject.CompareTag("ChangeColor"))
        {
            moving.runtimeAnimatorController = WhiteSlime as RuntimeAnimatorController;
            oppositeJump = true;
        }

    }


}
