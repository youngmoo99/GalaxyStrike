using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{   
    [SerializeField] string[] timelineTextLines; // 대화 텍스트 배열
    [SerializeField] TMP_Text dialogueText; // 화면에 표시될 TMP 텍스트

    int currentLine = 0; // 현재 표시 중인 대사 인덱스

    public void NextDialogueLine()
    {
        currentLine++; // 다음 문장으로 이동
        dialogueText.text = timelineTextLines[currentLine];
    }


}
