using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// Before it was a CameraController.
// However, this script can be generalized and applied to different components.
// For example: a cat can follow a player, just like a camera.
public class TargetFollower : MonoBehaviour
{
    // Public shoud be PascalCased
    // Properties should be used when exposing class data.
    // It should be used, because you don't want to allow everything to just change class data.
    // Sometimes you want to have read-only, write-only properties and not both.
    // With fields- you cannot have that.

    // This is a property- get/set methods.
    // This attribute is used for exposing property in Unity editor.
    // And this works only on fields, so we need to make a private one.
    [SerializeField]
    private Transform _target;
    public Transform target
    {
        get => _target;
        set => _target = value;
    }

    // This is a field- just data.
    // We extracted the 3 later fields, because they were tightly related.
    // The form a logical concept- settings.
    // Therefore it should be scripted so the intention is more clear why it is used.
    public FollowSettings settings;

    // Keep unity method's as clean as possible.
    // Ideally, it should just call a method and not hold implementation.
    private void LateUpdate()
    {
        Follow(target);
    }

    private void Follow(Transform target)
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);

            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}

public class FollowSettings 
{
    public float smoothing { get; set; }
    public Vector2 minPosition { get; set; }
    public Vector2 maxPosition { get; set; }
}
