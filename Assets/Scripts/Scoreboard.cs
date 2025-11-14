using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{   
    [SerializeField] TMP_Text scoreboardText; // 점수 UI 텍스트
    int score = 0; // 현재 점수

    // 점수 증가 및 UI 갱신
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();
    }
}
