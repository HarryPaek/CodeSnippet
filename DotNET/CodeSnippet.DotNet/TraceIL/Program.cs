using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;

namespace TraceIL
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("TraceIL.exe <assembly>");
                return;
            }

            string fileName = args[0];
            ModuleDefinition module = ModuleDefinition.ReadModule(fileName);
            MethodReference consoleWriteLine = module.ImportReference(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(object) }));

            foreach (TypeDefinition type in module.Types)
            {
                foreach (var methodDefinition in type.Methods)
                {
                    var ilBody = methodDefinition.Body;
                    var ilProcessor = ilBody.GetILProcessor();

                    var firstOp = methodDefinition.Body.Instructions.First();
                    var ldstrEntering = Instruction.Create(OpCodes.Ldstr, $"--Entering {methodDefinition.Name}");
                    ilProcessor.InsertBefore(firstOp, ldstrEntering);

                    var call = Instruction.Create(OpCodes.Call, consoleWriteLine);
                    ilProcessor.InsertBefore(firstOp, call);

                    var ldstrLeaving = Instruction.Create(OpCodes.Ldstr, $"--Leaving {methodDefinition.Name}");
                    var lastOp = methodDefinition.Body.Instructions.Last();
                    ilProcessor.InsertBefore(lastOp, ldstrLeaving);

                    ilProcessor.InsertBefore(lastOp, call);
                }
            }

            module.Write(Path.GetFileNameWithoutExtension(fileName) + ".modified" + Path.GetExtension(fileName));
        }
    }
}
