// Copyright 2020 by PeopleWare n.v..
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

using JetBrains.Annotations;

using Newtonsoft.Json;

using PPWCode.Vernacular.Exceptions.IV;

namespace PPWCode.API.Core.NewtonSoft.Json
{
    [UsedImplicitly]
    public class ByteArrayConverter : JsonConverter
    {
        public override bool CanRead
            => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new ProgrammingError($"Method {nameof(ReadJson)} not supported on {nameof(ByteArrayConverter)}");

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string base64String = Convert.ToBase64String((byte[])value);

            serializer.Serialize(writer, base64String);
        }

        public override bool CanConvert(Type t)
            => typeof(byte[]).IsAssignableFrom(t);
    }
}
