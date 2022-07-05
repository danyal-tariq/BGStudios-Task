using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Spine
{
    public class SkeletonAnimationControl : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnim;

        public void PlayAnimation(string anim)
        {
            StartCoroutine(SetAnimation(anim, false));
        }

        public void PlayAnimationLooped(string anim)
        {
            StartCoroutine(SetAnimation(anim, true));
        }

        private IEnumerator SetAnimation(string anim, bool loop = false)
        {
            var entry = skeletonAnim.AnimationState.SetAnimation(0, anim, loop);
            if (!loop)
                yield return new WaitForSpineAnimationComplete(entry);
            else
                yield return new WaitForSeconds(3f);
            skeletonAnim.AnimationState.SetAnimation(0, "idle", true);
            yield return null;
        }
    }
}