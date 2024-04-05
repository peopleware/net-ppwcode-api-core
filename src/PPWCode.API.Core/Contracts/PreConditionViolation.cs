// Copyright 2024 by PeopleWare n.v..
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using JetBrains.Annotations;
#if NETSTANDARD2_0
using System;
using System.Runtime.Serialization;
#endif

namespace PPWCode.API.Core.Contracts
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class PreConditionViolation : ContractViolation
    {
        public PreConditionViolation(
            [NotNull] string message,
            string filePath,
            string memberName,
            int? lineNumber)
            : base(message, filePath, memberName, lineNumber)
        {
        }

#if NETSTANDARD2_0
        protected PreConditionViolation(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
