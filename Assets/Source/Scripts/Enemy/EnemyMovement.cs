using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField] private float _enemySpeedMove;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float stoppingDistance = 0.5f;


    private CharacterController _enemyController;
    private Animator _enemyAnimator;
    private GameObject _player;
    private bool _isMoving;


    private void Start()
    {

        _enemyController = GetComponent<CharacterController>();
        _enemyAnimator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        EnemyMove();
       
    }



    private void EnemyMove()
    {
        if (_player != null)
        {

            Vector3 direction = _player.transform.position - transform.position;
            direction.y = 0;
            _enemyAnimator.SetBool("MoveForward", false);


            if (direction.magnitude > stoppingDistance)
            {

                Vector3 moveDirection = direction.normalized;
                _enemyController.Move(moveDirection * _enemySpeedMove * Time.deltaTime);
                _enemyAnimator.SetBool("MoveForward", true);

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}



   