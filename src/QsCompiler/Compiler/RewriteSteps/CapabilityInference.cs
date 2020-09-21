﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Quantum.QsCompiler.SyntaxTree;
using static Microsoft.Quantum.QsCompiler.SyntaxProcessing.CapabilityInference;

namespace Microsoft.Quantum.QsCompiler.BuiltInRewriteSteps
{
    /// <summary>
    /// Infers the minimum runtime capabilities required by each callable.
    /// </summary>
    internal class CapabilityInference : IRewriteStep
    {
        public string Name { get; } = "Capability Inference";

        public int Priority { get; } = RewriteStepPriorities.CapabilityInference;

        public IDictionary<string, string> AssemblyConstants { get; } =
            new Dictionary<string, string>();

        public IEnumerable<IRewriteStep.Diagnostic> GeneratedDiagnostics { get; } =
            Enumerable.Empty<IRewriteStep.Diagnostic>();

        public bool ImplementsPreconditionVerification { get; } = false;

        public bool ImplementsTransformation { get; } = true;

        public bool ImplementsPostconditionVerification { get; } = false;

        public bool PreconditionVerification(QsCompilation compilation) => throw new NotSupportedException();

        public bool Transformation(QsCompilation compilation, out QsCompilation transformed)
        {
            transformed = InferCapabilities(compilation);
            return true;
        }

        public bool PostconditionVerification(QsCompilation compilation) => throw new NotSupportedException();
    }
}