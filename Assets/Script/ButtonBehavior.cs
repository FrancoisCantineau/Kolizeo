using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void OnclickButton(string sceneName)
    {
        AudioManager.Instance.PlayUIClick();

        SceneTransitionManager.Instance.TransitionToScene(sceneName);
    }
}
