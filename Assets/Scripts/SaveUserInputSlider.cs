using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUserInputSlider : MonoBehaviour
{
    [SerializeField] public Slider slider;

    private void Start()
    {
        slider.value = GetFloat("Sens");

        slider.onValueChanged.AddListener(delegate { SetFloat("Sens", slider.value); });
    }

    public void SetFloat(string Keyname, float Value)
    {
        PlayerPrefs.SetFloat(Keyname, Value);
    }

    public float GetFloat(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName);
    }
}
