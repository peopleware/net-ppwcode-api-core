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

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using JetBrains.Annotations;

namespace PPWCode.API.Core
{
    [DataContract]
    public class Message : Dto
    {
        [DataMember]
        [Required]
        public bool? Translated { get; set; }

        [DataMember]
        [Required]
        public InfoLevelEnum? InfoLevel { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        [Required]
        public string[] Parameters { get; set; }

        [DataMember]
        public string Text { get; set; }

        [NotNull]
        public static Message CreateTranslatedMessage(InfoLevelEnum infoLevel, string code, params string[] parameters)
            => new Message
               {
                   Translated = true,
                   InfoLevel = infoLevel,
                   Code = code,
                   Parameters = parameters ?? new string[] { }
               };

        [NotNull]
        public static Message CreateUntranslatedMessage(InfoLevelEnum infoLevel, [NotNull] string text, params string[] parameters)
            => new Message
               {
                   Translated = false,
                   InfoLevel = infoLevel,
                   Code = "MESSAGE_CODE_EMPTY",
                   Text = text,
                   Parameters = parameters ?? new string[] { }
               };
    }
}
