﻿using Newtonsoft.Json;

using System;

namespace DomoticzNet.Service.Converters
{
    public class HexNumberConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader is null)
                throw new ArgumentNullException(nameof(reader));

            var str = reader.Value.ToString();
            return System.Convert.ChangeType(long.Parse(str, System.Globalization.NumberStyles.HexNumber), objectType);
        }

        public override bool CanConvert(Type t)
        {
            return t == typeof(byte)
                || t == typeof(ushort)
                || t == typeof(short)
                || t == typeof(uint)
                || t == typeof(int)
                || t == typeof(ulong)
                || t == typeof(long);
        }
    }
}
