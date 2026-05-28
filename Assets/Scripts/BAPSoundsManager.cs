using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System;

public class BAPSoundsManager : MonoBehaviour
{
    public static BAPSoundsManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public AudioMixer playerSoundsMixer;
    public AudioMixer gunSoundsMixer;

    public void ProcessGunSound(string exposedParameterName, float value) {
        ProcessMixerExposedParameterValue(playerSoundsMixer, exposedParameterName, value, 0.01f);
    }



    public void EnableFootstepReverb(float decayTimeValue) {
        ProcessMixerExposedParameterValue(playerSoundsMixer, "PlayerFootstepsSoundsReverbRoom", 0, 0.01f);
        ProcessMixerExposedParameterValue(playerSoundsMixer, "PlayerFootstepsSoundsReverbDecayTime", decayTimeValue, 0.01f);
    }
    public void DisableFootstepReverb() {
        ProcessMixerExposedParameterValue(playerSoundsMixer, "PlayerFootstepsSoundsReverbRoom", -10000, 0.3f);
    }



    // Utilities++++++++++++
    private void ProcessMixerExposedParameterValue(AudioMixer mixer, string exposedParameterName, float value, float duration = 1) {
        StartCoroutine(SetMixerParameterCoroutine(mixer, exposedParameterName, value, duration));   
    }
    private IEnumerator SetMixerParameterCoroutine(AudioMixer mixer, string exposedParameterName, float value, float duration = 1) {
        float timer = 0;
        float startValue = 0;
        mixer.GetFloat(exposedParameterName, out startValue);
        while (timer < duration) {
            mixer.SetFloat(exposedParameterName, Mathf.Lerp(startValue, value, timer / duration));
            timer += Time.deltaTime;
            yield return null;
        }
        mixer.SetFloat(exposedParameterName, value);
    }
    // Utilities------------
}
