using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCombat : MonoBehaviour
{
    public float attackDelay = 2f;
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    public bool InCombat { get; private set; }

    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats enemyStats;

    LayerMask layer;

    private void Start() {
        myStats = GetComponent<CharacterStats>();
        enemyStats = FindObjectOfType<EnemyStats>();
    }

    private void Update() {
        
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        Attack(enemyStats);
        
        attackCoolDown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (attackCoolDown <= 0f)
            {
                enemyStats = targetStats;
                StartCoroutine(AttackOn());
                attackCoolDown = 1f/attackSpeed;
            }
        }
    }

    IEnumerator AttackOn()
    {
        yield return new WaitForSeconds(attackDelay);
        
        if(OnAttack != null)
            OnAttack();
    }

    public void AttackHit_AnimationEvent()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, layer);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);

        enemyStats.TakeDamage(myStats.damage.GetValue());
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000);
    }
}
