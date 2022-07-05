using System.Collections;
using Spine.Unity;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D character;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 movementVector;

    [Header("Spine Animation")] [SerializeField]
    private SkeletonAnimation skeletonAnim;


    private void Start()
    {
        StartCoroutine(nameof(SetAnimation));
    }

    private void Update()
    {
        GetInputs();

        SetCharacterDirection(movementVector.x);
    }

    private void FixedUpdate()
    {
        SetMovement();
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
        character.MovePosition(character.position + movementVector * (movementSpeed * Time.fixedDeltaTime));
    }

    private void SetCharacterDirection(float x)
    {
        if (x < 0)
            skeletonAnim.skeleton.ScaleX = -1;
        else if (x > 0)
            skeletonAnim.skeleton.ScaleX = 1;
    }

    private IEnumerator SetAnimation()
    {
        var entry = skeletonAnim.AnimationState.GetCurrent(0);
        while (true)
        {
            if (movementVector.normalized.magnitude > 0.1)
            {
                if (entry.Animation.Name != "walk")
                    entry = skeletonAnim.AnimationState.SetAnimation(0, "walk", true);
            }
            else
            {
                if (entry.Animation.Name != "idle")
                    entry = skeletonAnim.AnimationState.SetAnimation(0, "idle", true);
            }

            yield return null;
        }
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