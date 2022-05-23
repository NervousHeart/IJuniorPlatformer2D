using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radiusCheckGround;

    private bool _isGrounded;
    private Vector3 _velocity;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    const string IsWalking = "IsWalking";

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeFlip();

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal")>0)
            _animator.SetBool(IsWalking,true);
        else
            _animator.SetBool(IsWalking, false);

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position,_radiusCheckGround, _layerMask);
        _velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rigidbody2D.velocity.y,0f);
        _rigidbody2D.velocity = _velocity;
    }

    private void ChangeFlip()
    {
        if (_velocity.x > 0)
            _spriteRenderer.flipX = false;
        else if (_velocity.x < 0)
            _spriteRenderer.flipX = true;
    }

}
