using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LiveCapture.CompanionApp;
using Unity.LiveCapture;

public class CompanionServerScript : MonoBehaviour
{
    public CompanionAppServer newSer;
    // Start is called before the first frame update
    void Start()
    {
        var servMag = ConnectionManager.Instance;
        newSer = (CompanionAppServer)servMag.CreateConnection(typeof(CompanionAppServer));
        newSer.AutoStartOnPlay = false;
        newSer.Port = 9080;
        newSer.StartServer();

    }
    private void OnDestroy()
    {
        if (newSer)
        {
            ConnectionManager.Instance.DestroyConnection(newSer);
            Debug.Log("Clean Server");
        }
    }

    private void OnGUI()
    {
        if (newSer)
        {
            // GUILayout.Label("PORT:" + newSer.Port.ToString());
            // GUILayout.Label("Running:" + newSer.IsRunning.ToString());
        }
        else
        {
            GUI.color = Color.red;
            GUILayout.Label("Server Not Found!");
            GUILayout.Label("PORT:--");
            GUILayout.Label("Running:--");
        }
    }

    // Update is called once per frame
    void Update()
    {
        newSer.OnUpdate();
    }
}
