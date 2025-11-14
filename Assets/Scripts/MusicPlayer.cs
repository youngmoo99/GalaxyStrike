using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //게임이 리셋되도 음악을 유지하기 위해 싱글톤 패턴 사용 
    void Start()
    {   
        // 현재 씬의 MusicPlayer 개수 확인
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        // 1개 이상이면 중복 제거 (새로 생긴 건 파괴)
        if(numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        {   
            // 씬 전환 시 유지
            DontDestroyOnLoad(gameObject);
        }
    }
}
