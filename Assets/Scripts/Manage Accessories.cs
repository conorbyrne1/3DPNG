using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAccessories : MonoBehaviour
{
    public GameObject accessory0, accessory1, accessory2, accessory3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && !accessory0.activeSelf)
        {
            accessory0.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) && accessory0.activeSelf)
        {
            accessory0.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && !accessory1.activeSelf)
        {
            accessory1.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1) && accessory1.activeSelf)
        {
            accessory1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && !accessory2.activeSelf)
        {
            accessory2.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) && accessory2.activeSelf)
        {
            accessory2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && !accessory3.activeSelf)
        {
            accessory3.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) && accessory3.activeSelf)
        {
            accessory3.SetActive(false);
        }

    }
}
