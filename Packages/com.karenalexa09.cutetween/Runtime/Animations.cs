using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace KarenAlexa09.CuteTween
{
    /// <summary> 
    /// Makes the object appear scaled from 0 to its normal size. 
    /// </summary>
    public class AppearAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 initialScale = Vector3.zero;
        [SerializeField] private Vector3 finalScale = Vector3.one;
        [SerializeField] private Ease appearEase = Ease.OutQuart;
        [SerializeField] private Ease fadeEase = Ease.Linear;
        [SerializeField] private string fadeProperty = "_Color";

        private Material currentMaterial = null;
        private Color originalColor;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            target.localScale = initialScale;

            Image image = target.GetComponent<Image>();
            Renderer renderer = target.GetComponent<Renderer>();

            if (image != null)
            {
                Material material = new Material(image.material);

                currentMaterial = material;

                image.material = material;

                originalColor = image.color;

                material.color = new Color(1, 1, 1, 0f);

            }
            else if (renderer != null)
            {
                Material material = new Material(renderer.material);

                currentMaterial = material;

                if (material.HasProperty(fadeProperty))
                {
                    renderer.material = material;

                    originalColor = material.color;

                    material.color = new Color(1, 1, 1, 0f);
                }
            }

            Sequence sequence = DOTween.Sequence();

            currentTween = sequence.Append(currentMaterial.DOFade(originalColor.a, duration).SetEase(fadeEase))
                                           .Join(target.DOScale(finalScale, duration).SetEase(appearEase)
                                           .OnComplete(() => completed?.Invoke())).SetAutoKill(true);
        }
    }

    /// <summary>
    /// It appears with a small bounce to give a springy feel.
    /// </summary>
    public class BounceAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f);
        [SerializeField] private Vector3 finalScale = Vector3.one;
        [SerializeField] private float bounceScale = 1.2f;
        [SerializeField] private float bounceDuration = 0.2f;
        [SerializeField] private Ease easeIn = Ease.OutBack;
        [SerializeField] private Ease easeBounce = Ease.InOutElastic;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            target.localScale = initialScale;

            currentTween = target.DOScale(finalScale, duration).SetEase(easeIn)
                .OnComplete(() =>
                    target.DOScale(finalScale * bounceScale, bounceDuration).SetEase(Ease.OutQuad)
                        .OnComplete(() =>
                            target.DOScale(finalScale, bounceDuration).SetEase(easeBounce)))
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Shake the object horizontally to indicate an error or warning.
    /// </summary>
    public class ShakeAnimation : CuteAnimationBase
    {
        [SerializeField] private float shakeStrength = 10f;
        [SerializeField] private int shakeVibrato = 10;
        [SerializeField] private float shakeRandomness = 90f;
        [SerializeField] private Ease shakeEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DOShakePosition(duration, shakeStrength, shakeVibrato, shakeRandomness).SetEase(shakeEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Rotates the object 360 degrees.
    /// </summary>
    public class SpinAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 rotationAxis = new Vector3(0, 0, 360);
        [SerializeField] private RotateMode rotateMode = RotateMode.FastBeyond360;
        [SerializeField] private Ease spinEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DORotate(rotationAxis, duration, rotateMode).SetEase(spinEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Moves the object from the direction to its initial position.
    /// </summary>
    public class SlideAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 slideDirection = new Vector3(0, 200, 0);
        [SerializeField] private float slideAmount = 200f;
        [SerializeField] private Ease slideEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            Vector3 startPos = target.position + slideDirection;
            target.position = startPos;
            currentTween = target.DOMoveY(startPos.y - slideAmount, duration).SetEase(slideEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Causes the object to enlarge and then return to its normal size.
    /// </summary>
    public class PulseAnimation : CuteAnimationBase
    {
        [SerializeField] private float pulseScale = 1.2f;
        [SerializeField] private float pulseDuration = 0.5f;
        [SerializeField] private Ease pulseEaseOut = Ease.OutQuad;
        [SerializeField] private Ease pulseEaseIn = Ease.InQuad;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DOScale(pulseScale, pulseDuration).SetEase(pulseEaseOut)
                .OnComplete(() => target.DOScale(1f, pulseDuration).SetEase(pulseEaseIn)
                    .OnComplete(() => completed?.Invoke()))
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// It causes the object to wobble from side to side as if it were hanging.
    /// </summary>
    public class SwingAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 swingRotation = new Vector3(0, 0, 15);
        [SerializeField] private int swingLoops = 6;
        [SerializeField] private LoopType swingLoopType = LoopType.Yoyo;
        [SerializeField] private Ease swingEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DORotate(swingRotation, duration).SetLoops(swingLoops, swingLoopType).SetEase(swingEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// It causes the object to spin in as if it were falling paper.
    /// </summary>
    public class PaperDropAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 initialScale = Vector3.zero;
        [SerializeField] private Vector3 finalScale = Vector3.one;
        [SerializeField] private Vector3 finalRotation = new Vector3(0, 0, 180);
        [SerializeField] private float rotationDuration = 0.5f;
        [SerializeField] private int loops = 2;
        [SerializeField] private Ease scaleEase = Ease.OutBounce;
        [SerializeField] private Ease rotationEase = Ease.OutBack;
        [SerializeField] private LoopType loopType = LoopType.Yoyo;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            target.localScale = initialScale;
            currentTween = target.DOScale(finalScale, duration).SetEase(scaleEase);
            target.DORotate(finalRotation, rotationDuration).SetLoops(loops, loopType).SetEase(rotationEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Causes the object to “jump” into place several times before standing still.
    /// </summary>
    public class JumpAnimation : CuteAnimationBase
    {
        [SerializeField] private float jumpHeight = 50f;
        [SerializeField] private int jumpNum = 3;
        [SerializeField] private Ease jumpEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DOJump(target.position, jumpHeight, jumpNum, duration).SetEase(jumpEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// It causes the object to tilt forward and then return.
    /// </summary>
    public class TiltAnimation : CuteAnimationBase
    {
        [SerializeField] private Vector3 tiltRotation = new Vector3(180, 0, 0);
        [SerializeField] private int tiltLoops = 2;
        [SerializeField] private LoopType tiltLoopType = LoopType.Yoyo;
        [SerializeField] private Ease tiltEase = Ease.Linear;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = target.DORotate(tiltRotation, duration).SetLoops(tiltLoops, tiltLoopType).SetEase(tiltEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// A playful squish effect when clicked, perfect for buttons.
    /// </summary>
    public class SquishyPopAnimation : CuteAnimationBase
    {
        [SerializeField] private float squishScaleX = 0.8f;
        [SerializeField] private float squishScaleY = 1.2f;
        [SerializeField] private float popDuration = 0.2f;
        [SerializeField] private Vector3 finalScale = Vector3.one;
        [SerializeField] private Ease squishEase = Ease.OutBack;
        [SerializeField] private Ease scaleEase = Ease.OutElastic;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            Sequence sequence = DOTween.Sequence();

           currentTween = sequence.Append(target.DOScaleX(squishScaleX, popDuration).SetEase(squishEase))
                   .Join(target.DOScaleY(squishScaleY, popDuration))
                   .Append(target.DOScale(finalScale, popDuration).SetEase(scaleEase))
                   .OnComplete(() => completed?.Invoke())
                   .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Gentle up/down floating effect, ideal for menu icons.
    /// </summary>
    public class FloatAnimation : CuteAnimationBase
    {
        [SerializeField] private int loops = -1;
        [SerializeField] private float floatHeight = 10f;
        [SerializeField] private float floatSpeed = 1f;
        [SerializeField] private Ease floatEase = Ease.InOutSine;
        [SerializeField] private LoopType loopsEase = LoopType.Yoyo;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            Vector3 startPos = target.position;

            currentTween = target.DOMoveY(startPos.y + floatHeight, floatSpeed)
                .SetEase(floatEase)
                .SetLoops(loops, loopsEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Stretches an object like elastic when dragged.
    /// </summary>
    public class ElasticStretchAnimation : CuteAnimationBase
    {
        [SerializeField] private float stretchFactor = 1.3f;
        [SerializeField] private Ease stretchEase = Ease.OutElastic;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            Vector3 originalScale = target.localScale;

            Sequence sequence = DOTween.Sequence();

            currentTween = sequence.Append(target.DOScaleX(originalScale.x * stretchFactor, duration)
                .SetEase(stretchEase))
                .Append(target.DOScale(originalScale, duration / 2))
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Mini particle burst for rewards/achievements.
    /// </summary>
    public class PressAnimation : CuteAnimationBase
    {
        [SerializeField] private float pressOffset = 4f;
        [SerializeField] private int loops = 2;
        [SerializeField] private LoopType loopType = LoopType.Yoyo;

        public override void PlayAnimation(Transform target, Action completed)
        {
            currentTween = target.DOMoveY(target.position.y - pressOffset, duration / 2)
                   .SetLoops(loops, loopType)
                   .OnComplete(() => completed?.Invoke())
                   .SetAutoKill(true);
        }
    }

    /// <summary>
    /// Playful wiggle for characters or icons.
    /// </summary>
    public class WigglyDanceAnimation : CuteAnimationBase
    {
        [SerializeField] private float wiggleAngle = 5f;
        [SerializeField] private int wiggleLoops = 1;
        [SerializeField] private Ease wiggleEase = Ease.InOutSine;
        [SerializeField] private LoopType loopType = LoopType.Yoyo;
        [SerializeField] private RotateMode rotateMode = RotateMode.LocalAxisAdd;

        private Quaternion _originalRotation;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            currentTween = DOTween.Sequence()
                .Append(target.DORotate(
                    new Vector3(0, 0, wiggleAngle),
                    duration / 2,
                    rotateMode
                ).SetEase(wiggleEase))
                .Append(target.DORotate(
                    new Vector3(0, 0, -wiggleAngle),
                    duration / 2,
                    rotateMode
                ).SetEase(wiggleEase))
                .SetLoops(wiggleLoops, loopType)
                .OnComplete(() => {
                    target.rotation = _originalRotation;
                    completed?.Invoke();
                })
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// 3D-style page flip for menus or tutorials.
    /// </summary>
    public class PageFlipAnimation : CuteAnimationBase
    {
        [SerializeField] private bool isReturn = false;
        [SerializeField] private Vector3 flipRotation = new Vector3(0, 180, 0);
        [SerializeField] private Ease flipEase = Ease.InOutBack;
        [SerializeField] private RotateMode rotateMode = RotateMode.LocalAxisAdd;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            if (isReturn)
            {
                Sequence sequence = DOTween.Sequence();

                currentTween = sequence.Append(target.DORotate(flipRotation, duration, rotateMode).SetEase(flipEase))
                    .Append(target.DORotate(-flipRotation, duration, rotateMode).SetEase(flipEase))
                    .OnComplete(() => completed?.Invoke())
                    .SetAutoKill(true);
            }
            else
            {
                currentTween = target.DORotate(flipRotation, duration, rotateMode)
                .SetEase(flipEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
            }
        }
    }

    /// <summary>
    /// Bouncy entry effect for popups.
    /// </summary>
    public class BouncyEntranceAnimation : CuteAnimationBase
    {
        [SerializeField] private float bounceHeight = 100f;
        [SerializeField] private Ease bounceEase = Ease.OutBounce;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            Vector3 originalPos = target.position;
            target.position = originalPos - new Vector3(0, bounceHeight, 0);

            currentTween = target.DOMoveY(originalPos.y, duration)
                .SetEase(bounceEase)
                .OnComplete(() => completed?.Invoke())
                .SetAutoKill(true);
        }
    }

    /// <summary>
    /// 3D tilt effect when hovering over cards.
    /// </summary>
    public class CardHoverAnimation : CuteAnimationBase
    {
        [SerializeField] private bool isReturn = false;
        [SerializeField] private Vector3 hoverRotation = new Vector3(10, 0, 0);
        [SerializeField] private float hoverHeight = 20f;
        [SerializeField] private Ease hoverEase = Ease.OutQuad;

        public override void PlayAnimation(Transform target, Action completed)
        {
            base.PlayAnimation(target, completed);

            float initialPosition = target.position.y;

            Sequence sequence = DOTween.Sequence();

            if (isReturn)
            {
                currentTween = sequence.Append(target.DOMoveY(target.position.y + hoverHeight, duration).SetEase(hoverEase))
                     .Join(target.DORotate(hoverRotation, duration).SetEase(hoverEase))
                     .Append(target.DOMoveY(initialPosition, duration).SetEase(hoverEase))
                     .OnComplete(() => completed?.Invoke())
                     .SetAutoKill(true);
            }
            else
            {
                currentTween = sequence.Append(target.DOMoveY(target.position.y + hoverHeight, duration).SetEase(hoverEase))
                    .Join(target.DORotate(hoverRotation, duration).SetEase(hoverEase))
                    .OnComplete(() => completed?.Invoke())
                    .SetAutoKill(true);
            }
        }
    }
}