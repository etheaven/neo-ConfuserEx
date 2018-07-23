using System.Collections.Generic;
using System.Linq;
using Confuser.Core;
using Confuser.Core.Helpers;
using Confuser.Core.Services;
using Confuser.Renamer;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Confuser.Protections
{
	[BeforeProtection("Ki.ControlFlow", "Ki.AntiTamper")]
	internal class ModuleFloodProtection : Protection
	{
		public const string _Id = "module flood";
		public const string _FullId = "Ki.ModuleFlood";

		public override string Name
		{
			get { return "Module Flood Protection"; }
		}

		public override string Description
		{
			get { return "This protection floods the module.cctor"; }
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
			get { return ProtectionPreset.Maximum; }
		}

		protected override void Initialize(ConfuserContext context)
		{
			//
		}

		protected override void PopulatePipeline(ProtectionPipeline pipeline)
		{
			pipeline.InsertPreStage(PipelineStage.ProcessModule, new ModuleFloodPhase(this));
		}

		class ModuleFloodPhase : ProtectionPhase
		{
			public ModuleFloodPhase(ModuleFloodProtection parent)
				: base(parent)
			{
			}

			public override ProtectionTargets Targets
			{
				get { return ProtectionTargets.Modules; }
			}

			public override string Name
			{
				get { return "Module flood"; }
			}

			protected override void Execute(ConfuserContext context, ProtectionParameters parameters)
			{
				TypeDef runtimeType = context.Registry.GetService<IRuntimeService>()
					.GetRuntimeType("Confuser.Runtime.ModuleFlood");
				IMarkerService service = context.Registry.GetService<IMarkerService>();
				INameService service2 = context.Registry.GetService<INameService>();
				foreach (ModuleDef moduleDef in parameters.Targets.OfType<ModuleDef>())
				{
					IEnumerable<IDnlibDef> enumerable =
						InjectHelper.Inject(runtimeType, moduleDef.GlobalType, moduleDef);
					MethodDef methodDef = moduleDef.GlobalType.FindStaticConstructor();
					MethodDef method2 =
						(MethodDef) enumerable.Single((IDnlibDef method) => method.Name == "Initialize");
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
					foreach (IDnlibDef def in enumerable)
					{
						service2.MarkHelper(def, service, (Protection) base.Parent);
					}
				}
			}
		}
	}
}