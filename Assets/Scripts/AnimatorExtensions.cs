using System.Collections;
using UnityEngine;

public static class AnimatorExtensions
{
    public static IEnumerator WaitForCurrentAnimation(this Animator animator)
    {
        yield return null;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1f)
        {
            yield return null;
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }
    }
}
