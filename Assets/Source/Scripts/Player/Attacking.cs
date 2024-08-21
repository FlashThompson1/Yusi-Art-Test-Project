using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Attacking : MonoBehaviour
{


    [SerializeField] private float _attackRadius;
    [SerializeField] private float _playerDamage;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private TextMeshProUGUI _hpText;
    public float _playerHP;

    private EnemyAttack _enemyHP;
    private Animator _playerAnimator;

   private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
     

    }

    
    private void Update()
    {
        _hpText.text = _playerHP.ToString();
        _enemyHP = FindAnyObjectByType<EnemyAttack>();
        Losing();
    }


    public void Attack() {


        if (_playerHP > 0) {
            
                StartCoroutine(AttackHolding());
           
        } 

       

    }


    private IEnumerator AttackHolding() {
        int randint = Random.Range(0, 5);

        switch (randint)
        {
            case 0:
                _playerAnimator.SetBool("Punch1", true);
                Debug.Log("Activated 1");
                break;
            case 1:
                _playerAnimator.SetBool("Punch2", true);
                Debug.Log("Activated 2");
                break;
            case 2:
                _playerAnimator.SetBool("Kick1", true);
                Debug.Log("Activated 3");
                break;
            case 3:
                _playerAnimator.SetBool("Kick2", true);
                Debug.Log("Activated 4");
                break;
            case 4:
                _playerAnimator.SetBool("Huck", true);
                Debug.Log("Activated 5");
                break;


        }
    if (Physics.CheckSphere(transform.position, _attackRadius,_enemy))
    {
        _enemyHP._enemyHP -= _playerDamage;
    }
        yield return new WaitForSeconds(0.4f);
        _playerAnimator.SetBool("Punch1", false);
        _playerAnimator.SetBool("Punch2", false);
        _playerAnimator.SetBool("Kick1", false);
        _playerAnimator.SetBool("Kick2", false);
        _playerAnimator.SetBool("Huck", false);
    }


    private void Losing() {
        if (_playerHP <= 0) {
            _playerAnimator.SetTrigger("Lose");
            Time.timeScale = 0;
            SceneMenegment.Instance.LosingPanel();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
