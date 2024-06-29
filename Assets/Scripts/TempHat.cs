using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;

public class TempHat : MonoBehaviour
{
    public string UserFile;

    public TextAsset imageAsset;

    public GameObject tempHat;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        tempHat.SetActive(true);

        var filter = new[] {
        new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };

        var FilePath = StandaloneFileBrowser.OpenFilePanel("Open File", "", filter, false);

        UserFile = FilePath[0];

        //UserFile = EditorUtility.OpenFilePanel("Select Image", "", "png, jpg, jpeg, tif, tiff, gif, bmp");

        byte[] bytes = File.ReadAllBytes(UserFile);

        // Create a texture. Texture size does not matter, since
        // LoadImage will replace with the size of the incoming image.
        Texture2D tex = new Texture2D(2, 2);
        ImageConversion.LoadImage(tex, bytes);
        tempHat.GetComponent<Renderer>().material.mainTexture = tex;
        


    }
}
