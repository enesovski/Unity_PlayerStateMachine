using UnityEngine;

namespace Solivagant.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayAnimation(string animationName)
        {
            if (animator == null) return;

            int animationHash = Animator.StringToHash(animationName);
            animator.Play(animationHash);
        }

        public void StopAnimation(string animationName)
        {
            if (animator == null) return;

            int animationHash = Animator.StringToHash(animationName);
            if (IsPlaying(animationHash))
            {
                animator.Play("Idle"); 
            }
        }

        public bool IsPlaying(int animationHash)
        {
            if (animator == null) return false;

            return animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationHash;
        }

        public void TriggerAnimation(string triggerName)
        {
            if (animator != null)
            {
                animator.SetTrigger(triggerName);
            }
        }

        public void SetFloat(string parameter, float value)
        {
            if (animator != null)
            {
                animator.SetFloat(parameter, value);
            }
        }
    }
}
