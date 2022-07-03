using DG.Tweening;
using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 movementVector;
    [SerializeField] private SkeletonAnimation skeletonAnim;


    //[SerializeField] private float speedMultiplier;

    private void Start()
    {
        StartCoroutine(nameof(SetAnimation));
    }
    private void Update()
    {
        GetInputs();
        SetMovement();
        SetCharacterDirection(movementVector.x);
        
    }

    #region Logics
    private void GetInputs()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

       
        movementVector = new Vector2(horizontal, vertical);

       
    }
    private void SetMovement()
    {
        character.Translate(movementVector*movementSpeed*Time.deltaTime);
    }
    private void SetCharacterDirection(float x)
    {
        if(x < 0)
            skeletonAnim.skeleton.ScaleX = -1;
        else
            skeletonAnim.skeleton.ScaleX = 1;
    }
    
    private IEnumerator SetAnimation()
    {
        TrackEntry entry = skeletonAnim.AnimationState.GetCurrent(0);
        while (true)
        {
            if (movementVector.normalized.magnitude > 0.1)
            {
                if(entry.Animation.Name!="walk")
                    entry = skeletonAnim.AnimationState.SetAnimation(0, "walk", true);
            }
            else
            {
                if (entry.Animation.Name != "idle")
                    entry = skeletonAnim.AnimationState.SetAnimation(0, "idle", true);
            }
            yield return null;
        }
        // skeletonAnim.skeleton.SetSlotsToSetupPose();
        // skeletonAnim.AnimationState.Update(0); // Advance internal state.
        // skeletonAnim.AnimationState.Apply(skeletonAnim.skeleton);
    }
    #endregion

}
public enum Direction
{
    Left,
    Right,
    Up,
    Down
}