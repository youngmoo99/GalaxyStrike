using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{   
    [SerializeField] GameObject[] lasers; //레이저
    [SerializeField] RectTransform crosshair; //조준선
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f; //조준선 목표 거리

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {   
        isFiring = value.isPressed; //value(마우스 좌클릭)를 클릭했는지 true false 확인 
    }
    void ProcessFiring()
    {   
        foreach (GameObject laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void MoveTargetPoint()
    {   
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; // 목표위치에서 레이저 위치를 가져오기
            Quaternion rotationToTarget =  Quaternion.LookRotation(fireDirection); // 레이저를  fireDirection 벡터에 맞추도록 회전을 계산
            laser.transform.rotation = rotationToTarget; // laser의 rotation을 방금 계산한 Quaternion쪽으로 이동
        }
    }
}
