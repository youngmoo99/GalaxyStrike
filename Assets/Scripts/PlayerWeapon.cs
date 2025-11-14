using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{   
    [SerializeField] GameObject[] lasers; // 발사 이펙트(파티클 레이저)
    [SerializeField] RectTransform crosshair; // UI 조준선
    [SerializeField] Transform targetPoint; // 조준 대상 포인트
    [SerializeField] float targetDistance = 100f; // 마우스 기준 거리

    bool isFiring = false; // 발사 중 여부

    void Start()
    {
        Cursor.visible = false; // 게임중 커서 숨김
    }
    void Update()
    {
        ProcessFiring(); // 발사 제어
        MoveCrosshair(); // 조준선 이동
        MoveTargetPoint(); // 마우스 → 월드 포인트 변환
        AimLasers(); // 레이저 방향 조정
    }
    
    // Input System Fire 액션 처리
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed; // 클릭 상태 저장
    }

    // 발사 이펙트 On/Off
    void ProcessFiring()
    {   
        foreach (GameObject laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }

    // 화면 내 마우스 위치를 UI Crosshair로 이동
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    // 카메라 화면 좌표 → 월드 좌표 변환 (조준 대상 포인트)
    void MoveTargetPoint()
    {   
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    
    // 모든 레이저의 발사 방향을 마우스 조준점으로 향하게 함
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
