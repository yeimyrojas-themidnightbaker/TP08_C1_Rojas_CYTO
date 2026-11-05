using UnityEngine;

public static class AnimatorStates
{
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Walk = Animator.StringToHash("Walk");
    public static readonly int Jump = Animator.StringToHash("Jump");
    public static readonly int Fall = Animator.StringToHash("Fall");
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int AttackUp = Animator.StringToHash("AttackUp");
    public static readonly int AttackDown = Animator.StringToHash("AttackDown");
    public static readonly int Shoot = Animator.StringToHash("Shoot");
    public static readonly int Ring = Animator.StringToHash("Ring");
    public static readonly int Hurt = Animator.StringToHash("Hurt");
    public static readonly int Lysis = Animator.StringToHash("Lysis");
    public static readonly int ToxicAnticipation = Animator.StringToHash("ToxicAnticipation");
    public static readonly int ToxicShoot = Animator.StringToHash("ToxicShoot");
}
