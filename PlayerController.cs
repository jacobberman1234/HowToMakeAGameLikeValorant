using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private float _gravity = -10f;
    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _groundDistance = 0.5f;

    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;
    private CharacterController _controller;
    private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Gravity();
        Movement();
        JumpAnimation();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        _controller.Move(move * _moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }

    private void Gravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void JumpAnimation()
    {
        _animator.SetBool("grounded", _isGrounded);
    }
}
