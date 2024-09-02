using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    public float smoothTime = 0.25f;
    Vector3 offset = new Vector3(0f, 0f, -10f);
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = targetPlayer.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
