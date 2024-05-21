using UnityEngine;

public class Probability : MonoBehaviour
{
    private static float _separation = 1;

    public void SetSplitChance(float value)
    {
        _separation = value;
    }

    public float GetSplitChance()
    {
        return _separation;
    }
}