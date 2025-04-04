using DG.Tweening;
using System;
using UnityEngine;

namespace KarenAlexa09.CuteTween
{ 
    [Serializable]
    public class CuteAnimationBase
    {
        [SerializeField] protected float duration = 0.5f;

        protected Tween currentTween;

        public virtual void PlayAnimation(Transform target, Action completedAnimation) 
        {
            if (currentTween != null && currentTween.IsActive())
            {
                currentTween.Kill();
            }
        }

        public Tween GetCurrentTween
        {
            get => currentTween;
        }
    }
}

