using System;
using DomoticzNet.Models;
using Newtonsoft.Json;

namespace DomoticzNet.Service.Converters
{
	public class ColorValueConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader is null)
				throw new ArgumentNullException(nameof(reader));
			if (serializer is null)
				throw new ArgumentNullException(nameof(serializer));

			if (reader.Value == null)
				return null;

			var value = reader.Value.ToString();
			if (string.IsNullOrEmpty(value))
				return null;

			var result = JsonConvert.DeserializeObject<ColorValue>(value);
			return result;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(ColorValue);
		}
	}
}