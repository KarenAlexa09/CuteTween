using System;
using UnityEngine;

namespace KarenAlexa09.CuteTween
{
    [Serializable]
    public class UIExample
    {
        public GameObject gameObject;
        public CuteTween tweenAnimation;
    }

    public class CuteTweenExample : MonoBehaviour
    {
        [SerializeField] private UIExample[] uIExamples;
        public void Play(int gameObjectIndex)
        {
            if (uIExamples[gameObjectIndex].gameObject != null && uIExamples[gameObjectIndex].tweenAnimation != null)
            {
                uIExamples[gameObjectIndex].tweenAnimation.PlayAnimation(uIExamples[gameObjectIndex].gameObject.transform);
            }
        }
    }
}

