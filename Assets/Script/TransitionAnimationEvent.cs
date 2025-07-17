using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationEvent : MonoBehaviour
{
    public void OnFullyCovered()
    {
        SceneTransitionManager.Instance.OnFullyCovered();
    }

    public void OnStartInTransition()
    {
        SceneTransitionManager.Instance.StartTransition();
    }
}
