﻿using UnityEngine;

/*
 * Sets structure for generic user based movement
 * 
 */
public class PlayerMovement : BaseMovement
{
    // Reference to the currently active character
    [SerializeField]
    protected PlayableCharacter m_player;

    public new void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();

        m_player = FindObjectOfType<PlayableCharacter>();
    }

    public override void Update()
    {
        Move();
	}

    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Move()
    {
        if ( (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) ))
        {
            // Make sure character is facing to the left
            if (FacingRight)
            {
                ChangeCharacterDirection();
            }

            // Move player to the left
            m_rigidbody.velocity = new Vector2(-m_moveSpeed, m_rigidbody.velocity.y);

            // Play characther's walking / running animation
            m_player.CharacterAnim.SetBool("IsMoving", true);
        }
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow) ))
        {
            // Make sure character is facing to the right
            if (!FacingRight)
            {
                ChangeCharacterDirection();
            }

            m_rigidbody.velocity = new Vector2(m_moveSpeed, m_rigidbody.velocity.y);

            // Play character's walking / running animation
            m_player.CharacterAnim.SetBool("IsMoving", true);
        }
        else
        {
            m_player.CharacterAnim.SetBool("IsMoving", false);
        }
    }
}
