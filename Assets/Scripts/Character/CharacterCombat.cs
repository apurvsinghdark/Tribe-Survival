using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 2f;
    private float attackCoolDown = 0f;
    private float lastAttackTime;
    private float combatCoolDown = 5f;
    public bool InCombat{get; private set;}

    public event System.Action OnAttack;

    private void Start() {
        InCombat = false;
    }

    private void Update() {
        
        attackCoolDown -= Time.deltaTime;

        //if(Time.time - lastAttackTime > combatCoolDown)
        //    InCombat = false;
    }

    public void Attack()
    {
        if (attackCoolDown <= 0f)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(OnAttack != null)
                    OnAttack();

                attackCoolDown = 1f/attackSpeed;
                //InCombat = true;
                lastAttackTime = Time.time;
            }
        }
    }
}
