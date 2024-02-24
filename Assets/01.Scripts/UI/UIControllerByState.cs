using UnityEngine;

/// <summary>
/// 게임의 상태별 UI를 관리하는 클래스
/// </summary>
public abstract class UIControllerByState : MonoBehaviour
{
    // 시작
    public abstract void EnterState();
    // 종료
    public abstract void ExitState();
}
