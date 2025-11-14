using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f; // 이동 속도
    [SerializeField] float xClampRange = 35f; // X축 이동 제한
    [SerializeField] float yClampRange = 20f; // Y축 이동 제한

    [SerializeField] float controlPitchFactor = 18f; // 상하 회전 강도
    [SerializeField] float controlRollFactor = 20f; // 좌우 회전 강도
    [SerializeField] float rotationSpeed = 10f; // 회전 보간 속도
   
    Vector2 movement; // 입력값 저장 (X,Y)

    void Update()
    {
        ProcessTranslation(); // 위치 이동
        ProcessRotation(); // 방향 회전
    }

    // Input System → Move 액션으로부터 입력값을 받음
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // 이동 처리 (좌우/상하)
    void ProcessTranslation() 
    {   
        //x축 이동량 계산 (좌/우)
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        //y축 이동량 계산 (위/아래)
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform. localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        // 최종 위치 적용
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f); 
    }

    // 이동 방향에 따라 비행선 회전
    void ProcessRotation() 
    {   
        //상하 기울기 계산 : 위로 이둥하면 음수방향으로 기울임
        float pitch = -controlPitchFactor * movement.y;

        //좌우 기울기 계산 : 오른쪽으로 이동하면 음수방향으로 기울임 
        float roll = -controlRollFactor * movement.x;
        
        // 목표 회전값 생성 (좌우 회전은 없음)
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        
        /// 회전 보간(Lerp)으로 부드럽게 전환
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);    
    }

}
