using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCombat : MonoBehaviour
{
    public float attackDelay = 2f;
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    private float lastAttackTime;
    private float combatCoolDown = 5f;
    public bool InCombat{get; private set;}

    public event System.Action OnAttack;

    private void Start() {
        InCombat = false;
    }

    private void Update() {
        
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        Attack();
        
        attackCoolDown -= Time.deltaTime;
    }

    public void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (attackCoolDown <= 0f)
            {  
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
}
