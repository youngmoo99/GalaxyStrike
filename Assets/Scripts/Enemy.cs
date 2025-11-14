using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] GameObject destroyedVFX; // 적 파괴 시 이펙트
    [SerializeField] int hitPoints = 3; // 적 체력
    [SerializeField] int scoreValue = 10; // 처치 시 점수

    Scoreboard scoreboard; // 점수판 참조

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    // 파티클 충돌 시 호출(레이저 등 ParticleSystem이 맞았을 때)
    //Non-trigger 콜라이더가있는 게임오브젝트에 부착될때 호출
    void OnParticleCollision(GameObject other) 
    {   
        ProcessHit();
    }

    // 적 피격 처리
    void ProcessHit()// 적 hp 감소
    {
        hitPoints--;
        if(hitPoints <= 0) // 체력 소진 시
        {   
            // 점수 추가
            scoreboard.IncreaseScore(scoreValue);
            // 폭발 효과
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            // 적 제거
            Destroy(this.gameObject);
        }
    }
}
