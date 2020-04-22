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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

namespace PPWCode.API.Core.Contracts
{
    [UsedImplicitly]
    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local", Justification = "The whole point is to validation conditions")]
    public static class Contract
    {
        [Conditional("CONTRACTS_PRE")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("condition: false => halt")]
        public static void Requires(
            bool condition,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (!condition)
            {
                throw new PreConditionViolation(
                    $"Pre-condition violated in method {memberName} on [{filePath}:{lineNumber}].",
                    filePath,
                    memberName,
                    lineNumber);
            }
        }

        [Conditional("CONTRACTS_POST")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("condition: false => halt")]
        public static void Ensures(
            bool condition,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (!condition)
            {
                throw new PostConditionViolation(
                    $"Post-condition violated in method {memberName} on [{filePath}:{lineNumber}].",
                    filePath,
                    memberName,
                    lineNumber);
            }
        }

        [Conditional("CONTRACTS_INVARIANT")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("condition: false => halt")]
        public static void Invariant(
            bool condition,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (!condition)
            {
                throw new InvariantViolation(
                    $"Invariant violated in method {memberName} on [{filePath}:{lineNumber}].",
                    filePath,
                    memberName,
                    lineNumber);
            }
        }

        [Conditional("CONTRACTS_ASSERT")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("condition: false => halt")]
        public static void Assert(
            bool condition,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (!condition)
            {
                throw new AssertViolation(
                    $"Assert violated in method {memberName} on [{filePath}:{lineNumber}].",
                    filePath,
                    memberName,
                    lineNumber);
            }
        }

        [Conditional("CONTRACTS_ASSERT")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("condition: false => halt")]
        private static void InternalAssert(
            bool condition,
            string filePath,
            string memberName,
            int lineNumber)
        {
            if (!condition)
            {
                throw new AssertViolation(
                    $"Assert violated in method {memberName} on [{filePath}:{lineNumber}].",
                    filePath,
                    memberName,
                    lineNumber);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        public static bool Assume(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            InternalAssert(condition, filePath, memberName, lineNumber);
            return true;
        }
    }
}
