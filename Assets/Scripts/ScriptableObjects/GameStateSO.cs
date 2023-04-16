using UnityEngine;

[CreateAssetMenu]
public class GameStateSO : ScriptableObject
{
    public IntEventChannelSO playerScoredChannel;
    private int _score = 0;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        SetScore(0);
    }

    [ContextMenu("Increment Score")]
    public void IncrementScore()
    {
        SetScore(_score + 1);
    }

    private void SetScore(int newScore)
    {
        _score = newScore;
        playerScoredChannel.RaiseEvent(_score);
    }
}
