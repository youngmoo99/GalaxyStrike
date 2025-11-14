using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{   
    // 현재 씬을 1초 후 리로드(플레이어 파괴 시 호출)
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }
    
    IEnumerator ReloadLevelRoutine()
    {   
        // 1초 딜레이
        yield return new WaitForSeconds(1f);
        // 씬 다시 불러오기
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
