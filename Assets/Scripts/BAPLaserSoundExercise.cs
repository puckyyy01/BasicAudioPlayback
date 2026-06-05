using UnityEngine;
using System.Collections.Generic;

public class BAPLaserSoundExercise : MonoBehaviour
{
    public AudioSource audioSource;
    public List<BAPMixerProcessedSoundParameter> exposedParameters;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            PlayGunSound();
        }
    }

    private void PlayGunSound() {
        audioSource.Play();
        if (exposedParameters!=null && exposedParameters.Count>0) {
            for (int i=0; i<exposedParameters.Count; i++) {
                BAPSoundsManager.instance.ProcessGunSound(exposedParameters[i].exposedParameterName, exposedParameters[i].value);
            }
        }
    }
}


[System.Serializable]
public class BAPMixerProcessedSoundParameter {
    public string exposedParameterName;
    public float value;
}