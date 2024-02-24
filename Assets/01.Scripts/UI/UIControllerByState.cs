using UnityEngine;

/// <summary>
/// ������ ���º� UI�� �����ϴ� Ŭ����
/// </summary>
public abstract class UIControllerByState : MonoBehaviour
{
    // ����
    public abstract void EnterState();
    // ����
    public abstract void ExitState();
}
