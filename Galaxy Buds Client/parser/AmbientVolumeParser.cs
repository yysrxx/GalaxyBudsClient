﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Galaxy_Buds_Client.message;
using Galaxy_Buds_Client.model;

namespace Galaxy_Buds_Client.parser
{
    class AmbientVolumeParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.MSG_ID_AMBIENT_VOLUME;
        public int AmbientVolume { set; get; }

        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            AmbientVolume = msg.Payload[0];
        }

        public override Dictionary<String, String> ToStringMap()
        {
            Dictionary<String, String> map = new Dictionary<string, string>();
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "HandledType" || property.Name == "ActiveModel")
                    continue;

                map.Add(property.Name, property.GetValue(this).ToString());
            }

            return map;
        }
    }
}
