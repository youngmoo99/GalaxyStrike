using UnityEngine;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] GameObject destroyedVFX; // 충돌 시 파괴 효과(Explosion VFX)
    GameSceneManager gameSceneManager; // 씬 리로드 담당 매니저

    void Start()
    {   
        // 씬 내에서 GameSceneManager를 찾아 참조
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {   
        // 플레이어가 피격되면 레벨 리로드  
        gameSceneManager.ReloadLevel();

        // 파괴 이펙트 생성 (플레이어 위치에)
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);

        // 플레이어 오브젝트 제거
        Destroy(this.gameObject);
    }
}
