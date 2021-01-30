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

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using PPWCode.API.Core.Extensions;

namespace PPWCode.API.Core.Services
{
    [UsedImplicitly]
    public class JsonFormatterService
        : Service,
          IJsonFormatterService
    {
        private readonly Lazy<JsonSerializerSettings> _cachedSettings;

        public JsonFormatterService(
            [NotNull] IOptions<MvcNewtonsoftJsonOptions> options)
        {
            Options = options.Value;
            _cachedSettings = new Lazy<JsonSerializerSettings>(() => Options.SerializerSettings);
        }

        [NotNull]
        public MvcNewtonsoftJsonOptions Options { get; }

        private JsonSerializerSettings CachedSettings
            => _cachedSettings.Value;

        public JsonSerializerSettings Settings
            => Options.SerializerSettings.DeepClone();

        /// <inheritdoc />
        public string SerializeObject<T>(T value, JsonSerializerSettings settings)
            => JsonConvert.SerializeObject(value, settings);

        /// <inheritdoc />
        public string SerializeObject<T>(T value)
            => JsonConvert.SerializeObject(value, CachedSettings);

        /// <inheritdoc />
        public T DeSerializeObject<T>(string value, JsonSerializerSettings settings)
            => JsonConvert.DeserializeObject<T>(value, settings);

        /// <inheritdoc />
        public T DeSerializeObject<T>(string value)
            => JsonConvert.DeserializeObject<T>(value, CachedSettings);
    }
}
