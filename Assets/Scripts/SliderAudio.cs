using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minVal;
    public Vector3 maxVal;
    public AudioDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    [SerializeField] public GameObject slider;

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMic() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        slider.GetComponent<Slider>().value = loudness;
    }

}
