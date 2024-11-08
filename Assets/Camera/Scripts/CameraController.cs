using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float followSpeed = 10f;

    private Vector3 offset;
    private Vector3 targetPosition;

    void Start()
    {
        player = GameObject.Find("Player").transform.GetChild(0).GetComponent<Transform>();
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

