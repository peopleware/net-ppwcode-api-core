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

namespace PPWCode.API.Core.Services
{
    public interface IJsonFormatterService : IService
    {
        [NotNull]
        JsonSerializerSettings Settings { get; }

        /// <summary>
        ///     Serializes the specified object to a JSON string using <see cref="T:Newtonsoft.Json.JsonSerializerSettings" />.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="settings">
        ///     The <see cref="T:Newtonsoft.Json.JsonSerializerSettings" /> used to serialize the object.
        ///     If this is <c>null</c>, default serialization settings will be used.
        /// </param>
        /// <typeparam name="T">The type of the object to serialize from.</typeparam>
        /// <returns>A JSON string representation of the object.</returns>
        [NotNull]
        string SerializeObject<T>([CanBeNull] T value, [NotNull] JsonSerializerSettings settings);

        /// <summary>
        ///     Serializes the specified object to a JSON string using <see cref="T:Newtonsoft.Json.JsonSerializerSettings" />.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <typeparam name="T">The type of the object to serialize from.</typeparam>
        /// <returns>A JSON string representation of the object.</returns>
        [NotNull]
        string SerializeObject<T>([CanBeNull] T value);

        /// <summary>
        ///     Deserializes the JSON to the specified .NET type using <see cref="T:Newtonsoft.Json.JsonSerializerSettings" />.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="settings">
        ///     The <see cref="T:Newtonsoft.Json.JsonSerializerSettings" /> used to deserialize the object.
        ///     If this is <c>null</c>, default serialization settings will be used.
        /// </param>
        /// <returns>The deserialized object from the JSON string.</returns>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="value" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="JsonReaderException">
        ///     If <paramref name="value" /> contains an invalid value, to serialize to <typeparamref name="T" />.
        /// </exception>
        [CanBeNull]
        T DeSerializeObject<T>([NotNull] string value, [NotNull] JsonSerializerSettings settings);

        /// <summary>
        ///     Deserializes the JSON to the specified .NET type using <see cref="T:Newtonsoft.Json.JsonSerializerSettings" />.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="value" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="JsonReaderException">
        ///     If <paramref name="value" /> contains an invalid value, to serialize to <typeparamref name="T" />.
        /// </exception>
        [CanBeNull]
        T DeSerializeObject<T>([NotNull] string value);
    }
}
