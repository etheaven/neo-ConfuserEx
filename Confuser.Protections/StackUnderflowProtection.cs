using System;
using Confuser.Core;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Confuser.Protections
{
	[BeforeProtection("Ki.ControlFlow")]
	internal class StackUnderflowProtection : Protection
	{
		public const string _Id = "stack underflow";
		public const string _FullId = "Ki.StackUnderflow";

		public override string Name
		{
			get { return "Stack Underflow Protection"; }
		}

		public override string Description
		{
			get { return "This protection adds code in front of methods causing decompilers to crash."; }
		}

		public override string Id
		{
			get { return _Id; }
		}

		public override string FullId
		{
			get { return _FullId; }
		}

		public override ProtectionPreset Preset
		{
			get { return ProtectionPreset.Minimum; }
		}

		protected override void Initialize(ConfuserContext context)
		{
			//
		}

		protected override void PopulatePipeline(ProtectionPipeline pipeline)
		{
			pipeline.InsertPreStage(PipelineStage.ProcessModule, new StackUnderflowPhase(this));
		}

		class StackUnderflowPhase : ProtectionPhase
		{
			public StackUnderflowPhase(StackUnderflowProtection parent)
				: base(parent)
			{
			}

			public override ProtectionTargets Targets
			{
				get { return ProtectionTargets.Methods; }
			}

			public override string Name
			{
				get { return "Stack underflowing"; }
			}

			protected override void Execute(ConfuserContext context, ProtectionParameters parameters)
			{
				foreach (IDnlibDef dnlibDef in parameters.Targets)
				{
					MethodDef methodDef = (MethodDef) dnlibDef;
					bool method = methodDef != null && !methodDef.HasBody;
					if (method)
					{
						break;
					}

					CilBody body = methodDef.Body;
					Instruction instruction = body.Instructions[0];
					Instruction instruction2 = Instruction.Create(OpCodes.Br_S, instruction);
					Instruction item = Instruction.Create(OpCodes.Pop);
					Random random = new Random();
					Instruction item2;
					switch (random.Next(0, 2))
					{
						case 0:
							item2 = Instruction.Create(OpCodes.Ldnull);
							break;
						case 1:
							item2 = Instruction.Create(OpCodes.Ldc_I4_0);
							break;
						case 2:
							item2 = Instruction.Create(OpCodes.Ldstr, "");
							break;
						default:
							item2 = Instruction.Create(OpCodes.Ldc_I8, (long) random.Next());
							break;
					}

					body.Instructions.Insert(0, item2);
					body.Instructions.Insert(1, item);
					body.Instructions.Insert(2, instruction2);
					foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
					{
						bool excep1 = exceptionHandler.TryStart == instruction;
						if (excep1)
						{
							exceptionHandler.TryStart = instruction2;
						}
						else
						{
							bool excep2 = exceptionHandler.HandlerStart == instruction;
							if (excep2)
							{
								exceptionHandler.HandlerStart = instruction2;
							}
							else
							{
								bool excep3 = exceptionHandler.FilterStart == instruction;
								if (excep3)
								{
									exceptionHandler.FilterStart = instruction2;
								}
							}
						}
					}
				}
			}
		}
	}
}