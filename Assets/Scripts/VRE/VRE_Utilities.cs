using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_Utilities : MonoBehaviour {

    public static VRE_Utilities _instance;

    void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Sets opacity of this GameObject and all its children
    /// </summary>
    /// <param name="g"></param>
    /// <param name="targetOpacity"></param>
    public void SetOpacity(GameObject g, float targetOpacity)
    {

        if (VRE_StateManager._instance._verbose == true)
            Debug.Log("SetOpacity called for " + g.name);


        // For this object
        Renderer r = g.GetComponent<Renderer>();
        if(r != null)
        {
            Debug.Log(g.name + " has a renderer, will call VRE_TweenHelper.OpacityFade");
            StartCoroutine(VRE_TweenHelper.OpacityFade(g, targetOpacity, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, "_Color"));
        }

        // For each child in transform
        foreach (Transform child in g.transform)
        {
            if (VRE_StateManager._instance._verbose == true)
                Debug.Log("For loop recognizes " + child.gameObject.name);

            Renderer cR = child.gameObject.GetComponent<Renderer>();

            if (cR != null) {
                if (VRE_StateManager._instance._verbose == true)
                    Debug.Log(child.gameObject.name + " has a renderer, will call VRE_TweenHelper.OpacityFade");

                StartCoroutine(VRE_TweenHelper.OpacityFade(child.gameObject, targetOpacity, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, "_Color"));
            }

        }

    }

    /// <summary>
    /// This method changes the state of any entity extending the UIElement interface
    /// </summary>
    /// <param name="uiElement"></param>
    /// <param name="toStateType"></param>
    public void ChangeStates(VRE_IUIElement uiElement, VRE_StateType toStateType)
    {
        if (VRE_StateManager._instance._verbose)
            Debug.Log("VRE_Utilities ChangeStates called");

        // What's the current state?
        VRE_State currentState = uiElement._states[uiElement._currentStateType];
        VRE_State defaultState = uiElement._states[VRE_StateType.Default];
        VRE_State targetState = uiElement._states[toStateType];

        // Tween between all elements of the state

        // Position
        Vector3 targetPosition = uiElement._defaultTransform._localPosition + targetState._positionOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalPositionWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localPosition, targetPosition, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Rotation
        Vector3 targetRotation = uiElement._defaultTransform._localRotation.eulerAngles + targetState._rotationOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalRotationWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localRotation.eulerAngles, targetRotation, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Scale
        Vector3 targetScale = uiElement._defaultTransform._localScale + targetState._scaleOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalScaleWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localScale, targetScale, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Material
        if (targetState._material != null)
        {
            Material targetMaterial = targetState._material;
            StartCoroutine(VRE_TweenHelper.ColorFade(uiElement._gameObject, targetMaterial, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing));
        }

        // finally change the UI Element's current state flag
        uiElement._currentStateType = toStateType;

    }

    /// <summary>
    /// Utility Method for triggering a haptic pulse to a specific controller
    /// </summary>
    /// <param name="hand"></param>
    /// <param name="strength"></param>
    public static void TriggerHapticPulse(Hand hand, float strength)
    {

        VRTK_ControllerReference controllerReference = null;
        if (hand == Hand.Right)
        {
            controllerReference = VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right);
        }
        if (hand == Hand.Left)
        {
            controllerReference = VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left);
        }

        TriggerHapticsAndAudio(controllerReference.model, controllerReference, strength, null);


    }

    /// <summary>
    /// Utility Method for triggering a haptic pulse and an audio clip.
    /// </summary>
    /// <param name="worldObject"></param>
    /// <param name="controllerReference"></param>
    /// <param name="strength"></param>
    /// <param name="audio"></param>
    public static void TriggerHapticsAndAudio(GameObject worldObject, VRTK_ControllerReference controllerReference, float strength, AudioClip audio)
    {

        // AudioSource audioSource = worldObject.AddComponent<AudioSource>();
        // audioSource.PlayOneShot(audio);
        AudioSource audioSource = TryGetAudioSource(worldObject);
        if (audio != null)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
        VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, strength, strength, 1.0f);

    }

    /// <summary>
    /// Utility method for checking for an audio source
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    public static AudioSource TryGetAudioSource(GameObject g)
    {

        if (VRE_StateManager._instance._verbose)
            Debug.Log("TryGetAudioSource called");

        AudioSource audioSource = g.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = g.AddComponent<AudioSource>();
        }

        return audioSource;

    }

    public static void SendMessageToChildren(GameObject g, string message)
    {

        // For each child in transform
        foreach (Transform child in g.transform)
        {

            Debug.Log("Sending message: " + message + " to " + child.gameObject.name);

            child.gameObject.SendMessage(message, SendMessageOptions.DontRequireReceiver);
        }

    }


}
