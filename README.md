# vot4cs
A Virtualization Obfuscation Tool for C# programs

==== USAGE ====

Usage: <tool> <config-file> <solution-file>
- tool: the .exe binary file
- config-file: an app.config file (see example bellow)
- solution-file: a Visual Studio .sln file containing the project to be obfuscated

 .\CodeVirtualization-Console\App2.config 	.\ConsoleCalculator\ConsoleCalculator.sln

==== OBFUSCATION CONFIGURATIONS ====

example: .\CodeVirtualization-Console\CodeVirtualization-Console\App2.config

key="CODE_IDENTIFIER" value="virtualCode2" 
key="DATA_IDENTIFIER" value="virtualData2" 
key="DEFAULT_MOST_FREQUENT_OPERATION" value="true" 
key="INSTRUCTION_SIZE_POSTFIX" value="30" 
key="INSTRUCTION_SIZE_PREFIX" value="30" 
key="INSTRUCTION_SIZE_OFFSET" value="20" 
key="MAX_INVOCATIONS" value="1" 
key="MAX_OPERANDS" value="2" 
key="MAX_JUNK_CODE" value="10" 
key="MAX_DATA_KEY" value="3999" 
key="MAX_CODE_KEY" value="99999" 
key="MIN_SWITCH_KEY" value="1000" 
key="MAX_SWITCH_KEY" value="9999" 
key="VPC_IDENTIFIER" value="virtualVpc" 


Mark a method for virtualization with the following annotation:


==== LANGUAGE FEATURES NOT SUPPORTED ====

- try/catch
- foreach 
- ref,
- struct


==== OBFUSCATION TOOL FOLDER: CodeVirtualization-Console ====

- contains the source code of the virtualization obfuscation tool



==== EXAMPLES FOLDER: ConsoleCalculator ====

- contains sample methods which can be obfuscated with the tool
- contains source code used for the performance evaluation of the virtualization
