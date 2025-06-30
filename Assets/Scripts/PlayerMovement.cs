using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xClampRange = 35f;
    [SerializeField] float yClampRange = 20f;

    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;
   


    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation() //wasd 상하좌우 이동 
    {   
        //x축 이동량 계산 (좌/우)
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        // 현재 위치에 이동량을 더한 임시 위치
        float rawXPos = transform.localPosition.x + xOffset;
        // x축 이동범위 제한(-xClampRange ~ xClampRange 까지)
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        //y축 이동량 계산 (위/아래)
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        // 현재 위치에 이동량을 더한 임시 위치
        float rawYPos = transform. localPosition.y + yOffset;
        // y축 이동범위 제한 (-yClampRange ~ -yClampRange 까지)
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f); 
    }
    void ProcessRotation() //이동 방향에 따라 회전 처리
    {   
        //상하 기울기 계산 : 위로 이둥하면 음수방향으로 기울임
        float pitch = -controlPitchFactor * movement.y;
        //좌우 기울기 계산 : 오른쪽으로 이동하면 음수방향으로 기울임 
        float roll = -controlRollFactor * movement.x;
        // 목표 회전값 생성 (좌우 회전은 없음)
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        // 현재 회전에서 목표 회전까지 부드럽게 보간 (Lerp)
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);    
    }

}
