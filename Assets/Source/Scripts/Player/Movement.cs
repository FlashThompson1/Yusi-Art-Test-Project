using UnityEngine;


public class Movement : MonoBehaviour
{
    [Header("Player Characteristics")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _gravity;

    [Header("Player Move KeyCodes")]
    [SerializeField] private Joystick _joystick;



    private Animator _playerAnimator;

    private Vector3 _velocity;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

   
   private void Update()
    {
        PlayerMovement();
        Rotation();

   
    }


    private void PlayerMovement()
    {

        //if (_playerStats.Health > 0)
        //{

        _playerAnimator.SetBool("MoveForward", false);
        _playerAnimator.SetBool("MoveBack", false);
        if (_joystick.Horizontal > 0 || _joystick.Vertical > 0) 
            _playerAnimator.SetBool("MoveForward",true);
        if (_joystick.Horizontal < 0 || _joystick.Vertical < 0)
            _playerAnimator.SetBool("MoveBack", true);




        Vector3 direction = transform.forward;
            direction.y = _controller.isGrounded ? 0 : -_gravity * Time.deltaTime;
            _controller.Move(new Vector3(direction.x * GetSpeed(), direction.y, direction.z * GetSpeed()));
        //}


    }

    private void Rotation() {
        //if (_playerStats.Health > 0)
        //{
            transform.Rotate(0, _joystick.Horizontal * _speedRotation * Time.deltaTime, 0);
        //}

    }

    private float GetSpeed()
       => _speedMove * _joystick.Vertical * Time.deltaTime;

}
