using System;
using UnityEngine;

namespace KarenAlexa09.CuteTween
{
    [Serializable]
    public class CuteTween
    {
        [SerializeField] private AnimationType selectedAnimation;

        [SerializeReference, SerializeField]
        private CuteAnimationBase animation;

        public CuteAnimationBase Animation => animation;

        public void PlayAnimation(Transform target, Action completed = null)
        {
            animation?.PlayAnimation(target, completed);
        }
    }
}