

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
        int preset = 0;



    void Update()
            {
                if (Input.GetKeyDown(this.debugKey))
                {
                    OSCHandler.Instance.SendMessageToClient(this.serverId, this.debugMessage, preset); //to change preset number, timeSinceLevelLoad
                }
            }
    }

