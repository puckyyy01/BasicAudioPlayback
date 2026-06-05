using UnityEngine;

public class BAPReverbTriggerArea : MonoBehaviour
{
    public float decayTimeValue = 1;  

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            BAPSoundsManager.instance.EnableFootstepReverb(decayTimeValue);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            BAPSoundsManager.instance.DisableFootstepReverb();
        }
    }

}
