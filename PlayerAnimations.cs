using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _speed;
    private float _horizontalSpeed;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        AnimatePlayerMovement();
    }

    private void AnimatePlayerMovement()
    {
        _speed = Input.GetAxis("Vertical");
        _horizontalSpeed = Input.GetAxis("Horizontal");

        _animator.SetFloat("speed", _speed);
        _animator.SetFloat("horizontal speed", _horizontalSpeed);
    }
}
