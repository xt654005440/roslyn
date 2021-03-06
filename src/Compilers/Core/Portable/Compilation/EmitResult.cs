﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;

namespace Microsoft.CodeAnalysis.Emit
{
    /// <summary>
    /// The result of the Compilation.Emit method.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class EmitResult
    {
        private readonly bool _success;
        private readonly ImmutableArray<Diagnostic> _diagnostics;

        /// <summary>
        /// True if the compilation successfully produced an executable.
        /// If false then the diagnostics should include at least one error diagnostic
        /// indicating the cause of the failure.
        /// </summary>
        public bool Success
        {
            get { return _success; }
        }

        /// <summary>
        /// A list of all the diagnostics associated with compilations. This include parse errors, declaration errors,
        /// compilation errors, and emitting errors.
        /// </summary>
        public ImmutableArray<Diagnostic> Diagnostics
        {
            get { return _diagnostics; }
        }

        internal EmitResult(bool success, ImmutableArray<Diagnostic> diagnostics)
        {
            _success = success;
            _diagnostics = diagnostics;
        }

        protected virtual string GetDebuggerDisplay()
        {
            string result = "Success = " + (Success ? "true" : "false");
            if (Diagnostics != null)
            {
                result += ", Diagnostics.Count = " + Diagnostics.Length;
            }
            else
            {
                result += ", Diagnostics = null";
            }

            return result;
        }
    }
}
