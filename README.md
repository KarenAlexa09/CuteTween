# CuteTween

![Demo GIF](https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExMG91M3FhNHkwb3gzdHFvYjNpNnp0cHh1dTUyNmRocXhlNW9rdWVuNCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/uM7D4HuflG5As8TJ4f/giphy.gif)

## 🌟 One-Click Installation
Add CuteTween to your Unity project instantly via Package Manager:
```
https://github.com/KarenAlexa09/CuteTween.git?path=/Packages/com.karenalexa09.cutetween
```

Or find it in Unity Package Manager under:
`Window > Package Manager > + > Add package from git URL`

## 🎯 Features

- **15+ Ready-to-Use Animations** - Bounce, spin, shake, and more
- **Simple API** - Just call `PlayAnimation()` on any GameObject
- **Customizable** - Adjust timing, easing, and parameters for each effect
- **UI & 3D Ready** - Works with both UI elements and 3D objects
- **DOTween Powered** - Smooth performance with proven tweening engine

## 🚀 Getting Started

1. **Installation**
   - Install via the Unity Package Manager using the URL above
   - OR import the package manually from GitHub releases

2. **Basic Usage**
```csharp
// Get reference to your CuteTween component
public CuteTween myTween; 

// Play animation on any GameObject
myTween.PlayAnimation(targetObject.transform);
```

## ✨ Animation Types

Here's the complete list of all animation types included in CuteTween, formatted for your README.md:

## ✨ Complete Animation Catalog

### 🎯 Core Animations

| Animation | Description | Parameters | Best For |
|-----------|-------------|------------|----------|
| **Appear** | Smooth fade-in with scaling | `initialScale`, `finalScale`, `fadeProperty` | UI popups, object spawns |
| **Bounce** | Playful springy entrance | `bounceScale`, `bounceDuration` | Buttons, notifications |
| **Shake** | Attention-grabbing vibration | `shakeStrength`, `vibrato` | Errors, warnings |
| **Spin** | Continuous rotation | `rotationAxis`, `rotateMode` | Loading indicators |
| **Slide** | Smooth directional movement | `slideDirection`, `slideAmount` | Menu transitions |

### 🦄 Special Effects

| Animation | Description | Parameters | Best For |
|-----------|-------------|------------|----------|
| **Pulse** | Gentle size pulsation | `pulseScale`, `pulseDuration` | Notifications, highlights |
| **Swing** | Pendulum-like wobble | `swingRotation`, `swingLoops` | Hanging objects, signs |
| **PaperDrop** | Falling paper effect | `finalRotation`, `loops` | Card games, documents |
| **Jump** | Bouncy hop motion | `jumpHeight`, `jumpNum` | Characters, icons |
| **Tilt** | Forward-backward rocking | `tiltRotation`, `tiltLoops` | Interactive elements |

### 🎮 Interactive Animations

| Animation | Description | Parameters | Best For |
|-----------|-------------|------------|----------|
| **SquishyPop** | Cartoon squash & stretch | `squishScaleX/Y`, `popDuration` | Game characters, buttons |
| **Float** | Gentle up/down motion | `floatHeight`, `floatSpeed` | Menu icons, collectibles |
| **ElasticStretch** | Rubber-band like stretch | `stretchFactor` | Drag-and-drop elements |
| **Press** | Button depression effect | `pressOffset` | All clickable UI |
| **WigglyDance** | Playful rotation wobble | `wiggleAngle`, `wiggleLoops` | Characters, rewards |

### 🖥️ UI-Specific Animations

| Animation | Description | Parameters | Best For |
|-----------|-------------|------------|----------|
| **PageFlip** | 3D-style page turn | `flipRotation`, `isReturn` | Tutorials, books |
| **BouncyEntrance** | Springy pop-in effect | `bounceHeight` | Dialog boxes |
| **CardHover** | 3D tilt on hover | `hoverRotation`, `hoverHeight` | Card games, portfolios |

## 🔧 Parameter Guide
Each animation exposes customizable properties:
- `duration`: Total animation time (seconds)
- `ease`: Easing function (OutBack, InOutSine, etc.)
- Animation-specific parameters (see tables above)

Example customization:
```csharp
// Get the animation component
var bounce = GetComponent<BounceAnimation>();

// Adjust parameters at runtime
bounce.bounceScale = 1.5f;
bounce.duration = 0.7f;
```

All animations work with both UI (RectTransform) and 3D objects!

## 📦 Dependencies

- [DOTween](http://dotween.demigiant.com/)

## 📜 License
MIT License - Free for commercial and personal use

---

**Happy Animating!** 🎨✨  
For support or feature requests, please open an issue on [GitHub](https://github.com/KarenAlexa09/CuteTween).

*"Make your UI dance with CuteTween!"* - KarenAlexa09
