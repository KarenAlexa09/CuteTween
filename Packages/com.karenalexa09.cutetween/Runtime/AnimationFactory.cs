using System.Collections.Generic;
using System;

namespace KarenAlexa09.CuteTween
{
    public static class AnimationFactory 
    {
        private static readonly Dictionary<AnimationType, Type> animationTypes = new();

        static AnimationFactory()
        {
            RegisterAnimations();
        }

        public static CuteAnimationBase CreateAnimation(AnimationType type)
        {
            Type animationType = GetAnimationType(type);
            return animationType != null ? Activator.CreateInstance(animationType) as CuteAnimationBase : null;
        }

        private static void RegisterAnimations()
        {
            animationTypes[AnimationType.Bounce] = typeof(BounceAnimation);
            animationTypes[AnimationType.Appear] = typeof(AppearAnimation);
            animationTypes[AnimationType.Jump] = typeof(JumpAnimation);
            animationTypes[AnimationType.Spin] = typeof(SpinAnimation);
            animationTypes[AnimationType.PaperDrop] = typeof(PaperDropAnimation);
            animationTypes[AnimationType.Pulse] = typeof(PulseAnimation);
            animationTypes[AnimationType.Shake] = typeof(ShakeAnimation);
            animationTypes[AnimationType.Slide] = typeof(SlideAnimation);
            animationTypes[AnimationType.Swing] = typeof(SwingAnimation);
            animationTypes[AnimationType.Tilt] = typeof(TiltAnimation);
            animationTypes[AnimationType.SquishyPop] = typeof(SquishyPopAnimation);
            animationTypes[AnimationType.FloatingHover] = typeof(FloatAnimation);
            animationTypes[AnimationType.ElasticStretch] = typeof(ElasticStretchAnimation);
            animationTypes[AnimationType.Press] = typeof(PressAnimation);
            animationTypes[AnimationType.WigglyDance] = typeof(WigglyDanceAnimation);
            animationTypes[AnimationType.PageFlip] = typeof(PageFlipAnimation);
            animationTypes[AnimationType.BouncyEntrance] = typeof(BouncyEntranceAnimation);
            animationTypes[AnimationType.CardHover] = typeof(CardHoverAnimation);
        }

        public static Type GetAnimationType(AnimationType type) =>
            animationTypes.TryGetValue(type, out Type animType) ? animType : null;
    }
}
