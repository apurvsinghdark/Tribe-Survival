using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CharacterAnimator : MonoBehaviour
{
    public static CharacterAnimator instance;

    private void Awake() {
        if (instance != null)
        {
            DontDestroyOnLoad(instance);
        }
        else
        {
            instance = this;
        }
    }
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;

    protected CharacterCombat combat;
    [NonSerialized] public Animator animator;

    protected virtual void Start() {
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        currentAttackAnimSet = defaultAttackAnimSet;
        //combat.OnAttack += OnAttack; //Add Attack Animation
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0,currentAttackAnimSet.Length);
    }
}
