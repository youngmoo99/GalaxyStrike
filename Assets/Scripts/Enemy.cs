using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard; //점수 

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    void OnParticleCollision(GameObject other) //Non-trigger 콜라이더가있는 게임오브젝트에 부착될때 호출
    {   
        ProcessHit();
    }

    void ProcessHit()// 적 hp 감소
    {
        hitPoints--;
        if(hitPoints <= 0) //3번 적중시 파괴
        {   
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
