using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Spine
{
    public class SkeletonGraphicAnimationControl : MonoBehaviour
    {
        [SerializeField] private SkeletonGraphic skeletonAnim;

        public void PlayAnimation(string anim)
        {
            StartCoroutine(SetAnimation(anim));
        }

        private IEnumerator SetAnimation(string anim)
        {
            var entry = skeletonAnim.AnimationState.SetAnimation(0, anim, false);
            yield return new WaitForSpineAnimationComplete(entry);
            skeletonAnim.AnimationState.SetAnimation(0, "idle", true);
            yield return null;
        }
    }
}