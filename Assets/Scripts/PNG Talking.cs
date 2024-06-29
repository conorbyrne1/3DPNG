using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGTalking : MonoBehaviour
{
    public AudioSource source;

    public AudioDetection detector;

    public Material closedMouth;
    public Material openMouth;

    public GameObject plane;
    [SerializeField] public GameObject slider;

    public float loudnessSensibility = 100;
    public float threshold = 1f;

    float time;
    float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        plane.GetComponent<MeshRenderer>().material = closedMouth;
        time = 0f;
        timeDelay = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSliderPos = slider.GetComponent<Slider>().value;

        time = time + 1f * Time.deltaTime;

        float loudness = detector.GetLoudnessFromMic() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        if (loudness >= currentSliderPos)
        {
            Talking();
        }

        else if (loudness < currentSliderPos)
        {
            if (time >= timeDelay)
            {
                time = 0f;
                StopTalking();
            }
        }
    }
    void Talking()
    {
        plane.GetComponent<MeshRenderer>().material = openMouth;
    }
    void StopTalking()
    {
        plane.GetComponent<MeshRenderer>().material = closedMouth;
    }
}
