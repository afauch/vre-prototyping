using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public enum Hand
{
    Left,
    Right
}

public class TransitionUtility {


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


    public static AudioSource TryGetAudioSource(GameObject g)
    {

            Debug.Log("TryGetAudioSource called");

        AudioSource audioSource = g.GetComponent<AudioSource>();
        if(audioSource == null)
        {
            audioSource = g.AddComponent<AudioSource>();
        }

        return audioSource;

    }

}
