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

using Newtonsoft.Json;

namespace PPWCode.API.Core.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.All
            };

        public static T DeepClone<T>(this T obj)
        {
            string serializedObject = JsonConvert.SerializeObject(obj, typeof(T), _settings);
            object clone = JsonConvert.DeserializeObject(serializedObject, typeof(T), _settings);

            return (T)clone;
        }
    }
}
