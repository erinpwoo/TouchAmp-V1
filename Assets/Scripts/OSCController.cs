

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityOSC;
    
    public class OSCController : MonoBehaviour
    {
        
        public string serverId = "MaxMSP";
        public string serverIp = "127.0.0.1";
        public int serverPort = 7400;
        // Use this for initialization
        void Start()
        {
            OSCHandler.Instance.Init(this.serverId, this.serverIp, this.serverPort);
        }

        public KeyCode debugKey = KeyCode.S;
        public string debugMessage = "/sample";
   
    // Update is called once per frame
    void Update()
        {
            if (Input.GetKeyDown(this.debugKey))
            {
                OSCHandler.Instance.SendMessageToClient(this.serverId, this.debugMessage,34); //to change preset number, timeSinceLevelLoad
            }
        }
    }

