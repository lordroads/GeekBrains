
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Program
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module Program.exe
// MVID: {9F88A7B9-DD58-4F99-B282-3522406D7B65}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0A270000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Task_1.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       107 (0x6b)
    .maxstack  2
    .locals init (string V_0,
             string V_1,
             string V_2,
             string V_3,
             bool V_4)
    IL_0000:  nop
    IL_0001:  ldstr      "crackILDasm"
    IL_0006:  stloc.0
    IL_0007:  ldstr      "ILDasm"
    IL_000c:  stloc.1
    IL_000d:  ldstr      "Hello!\nEnter your login..."
    IL_0012:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0017:  nop
    IL_0018:  call       string [mscorlib]System.Console::ReadLine()
    IL_001d:  stloc.2
    IL_001e:  ldstr      "Okey, enter password..."
    IL_0023:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0028:  nop
    IL_0029:  call       string [mscorlib]System.Console::ReadLine()
    IL_002e:  stloc.3
    IL_002f:  ldloc.2
    IL_0030:  ldloc.0
    IL_0031:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0036:  brfalse.s  IL_0041

    IL_0038:  ldloc.3
    IL_0039:  ldloc.1
    IL_003a:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_003f:  br.s       IL_0042

    IL_0041:  ldc.i4.0
    IL_0042:  stloc.s    V_4
    IL_0044:  ldloc.s    V_4
    IL_0046:  brfalse.s  IL_0057

    IL_0048:  nop
    IL_0049:  ldstr      "Ok!"
    IL_004e:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0053:  nop
    IL_0054:  nop
    IL_0055:  br.s       IL_0064

    IL_0057:  nop
    IL_0058:  ldstr      "Error..."
    IL_005d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0062:  nop
    IL_0063:  nop
    IL_0064:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey()
    IL_0069:  pop
    IL_006a:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Task_1.Program


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 D:\Projects\GeekBrains\Lessond-7\Task-1\TaskPatched.res
