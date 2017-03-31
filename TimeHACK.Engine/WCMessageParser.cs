﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeHACK.Engine
{
    class WCMessageParser
    {
        public string ParseMessage(string json, int index, string user)
        {
            JObject message = JObject.Parse(JObject.Parse(json)["messages"][index].ToString());
            string newmsg = message["message"].ToString().Replace("@user", user);
            return message["user"].ToString() + ": " + newmsg;
        }
        public int GetMessageDelay(string json, int index)
        {
            JObject message = JObject.Parse(JObject.Parse(json)["messages"][index].ToString());
            return message["delay"].ToObject<int>();
        }
    }
}
