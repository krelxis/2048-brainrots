using UnityEngine;
using DG.Tweening;

public class TweenEffect : MonoBehaviour
{
    [HideInInspector] public Sequence Sequence; 
    public virtual void Awake()
    {
        DOTween.Init();
    }
}
