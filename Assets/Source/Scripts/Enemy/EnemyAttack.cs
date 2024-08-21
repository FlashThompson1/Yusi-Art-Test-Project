using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _enemyDamage;
    [SerializeField] public float _enemyHP;
    [SerializeField] private LayerMask _playerMask;

    private Attacking _player;
    private Animator _enemyAnimator;

    private bool _isAttacking = true;
    private bool _isCoroutineRunning = false;

    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _player = FindAnyObjectByType<Attacking>();
    }

    void Update()
    {
        Attack();
        Losing();   
    }

    private void Attack()
    {
        if (Physics.CheckSphere(transform.position, _attackRadius, _playerMask))
        {
            if (_isAttacking && !_isCoroutineRunning)
            {
                StartCoroutine(AttackHolding());
            }
        }
    }

    private IEnumerator AttackHolding()
    {
        _isCoroutineRunning = true;

        yield return new WaitForSeconds(1f);

        int randint = Random.Range(0, 5);

        switch (randint)
        {
            case 0:
                _enemyAnimator.SetBool("Punch1", true);
                break;
            case 1:
                _enemyAnimator.SetBool("Punch2", true);
                break;
            case 2:
                _enemyAnimator.SetBool("Kick1", true);
                break;
            case 3:
                _enemyAnimator.SetBool("Kick2", true);
                break;
            case 4:
                _enemyAnimator.SetBool("Huck", true);
                break;
        }


        float animationDuration = 2f;  
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            _player._playerHP -= _enemyDamage;
            yield return new WaitForSeconds(2f);
            elapsedTime += 2f;
            _enemyAnimator.SetBool("Punch1", false);
            _enemyAnimator.SetBool("Punch2", false);
            _enemyAnimator.SetBool("Kick1", false);
            _enemyAnimator.SetBool("Kick2", false);
            _enemyAnimator.SetBool("Huck", false);
        }


       

     
        _isAttacking = true;
        _isCoroutineRunning = false;
        yield return new WaitForSeconds(1f);  
    }



    private void Losing()
    {
        if (_enemyHP <= 0)
        {
            _enemyAnimator.SetTrigger("Lose");
            gameObject.SetActive(false);
        }
    }


    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
