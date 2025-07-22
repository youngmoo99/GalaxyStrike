using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //게임이 리셋되도 음악을 유지하기 위해 싱글톤 패턴 사용 
    void Start()
    {   
        // scene 내 음악 플레이어수 반환
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        //음악플레이어 1개만 , 새로운 음악플레이어 없애기 
        if(numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
