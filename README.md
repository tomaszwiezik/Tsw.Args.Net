# Introduction

## Terminology

* `Positional argument  s` - Arguments that must be provided in a specific order.
* `Options` - Typically optional arguments which can be provided in any order. By default, options are recognized by preceding `--` (double hyphen). An option can be a boolean switch (i.e., `--force`), or accept a value (i.e., --retries=5).
* `Option shortcut` - An alternative short name for an option. By default, shortcuts are recognized by preceding `-` (single hyphen).
* `Argument definition class` - A class decorated with the `[Arguments]` attribute, whose properties receive values from parsed arguments.
* `Simple syntax` - A scenario in which all arguments are defined in a single argument definition class.
* `Syntax variants` - in this scenario arguments are divided into separate sets, each with its own positional arguments and options.


# Quick start

Quick start examples likely cover most cases required by command-line applications. To apply one of these patterns, the following conditions must be met:
* The parser uses default settings.
* Argument definition class(es) are defined in one of the assemblies automatically loaded by the application.

## Argument definition class

Properties od argument definition class are mapped to parsed command-line arguments. Both the class and the properties must be decorated with obligatory attributes, which are listed below.

Required class attributes:
* `[Arguments]` - Denotes the class as an argument definition class.
* `[Doc("Syntax general description")]` - Obligatory, required by the help generator.

Required property attributes for positional arguments:
* `[Argument(Name="argument_name", Required=true|false, RequiredValue="argument_value", Position=0,1,...)]`
	- `Name` - Argument name, used by the help generator.
	- `Required` - Determines if the argument is obligatory, or not. Non-obligatory arguments must be assigned with a default value.
	- `RequiredValue` - Use this parameter when the argument expects a specific value.
	- `Position` - Zero-based index of the positional argument.
* `[Doc("Argument description")]` - Obligatory, required by the help generator.

Required property attributes for options:
* `[Option(Name="option_name", Required=true|false, ShortcutName="shortcut_name")]`
	- `Name` - Option name without prepending `--` characters.
	- `Required` - Determines if the option is obligatory, or not. Non-obligatory options must be assigned with a default value.
	- `ShortcutName` - An alternative short name for an option without preceding `-` character. This parameter is not obligatory and is usually used with the most commonly used options.
* `[Doc("Argument description")]` - Obligatory, required by the help generator.

> [!IMPORTANT]
> All properties must be of nullable types.
> Supported types:
> - arguments: `decimal`, `int`, `long`, `short`, `string`
> - options: `bool`, `decimal`, `int`, `long`, `short`, `string`, `List<decimal>`, `List<int>`, `List<long>`, `List<short>`, `List<string>`
> All optional arguments and options must have a default value.

See examples of argument definition classes in the following sections.

## Simple syntax

You can use simple syntax when the application contains exactly one argument definition class, which supports all combinations of arguments and options.

### Example

`myApp` application is a command-line app which copies files and accepts the following arguments:

```
myApp <src_file> <dest_file> [--quiet | -q] [--retry=N]
```

Argument definition class:

```cs
namespace TW.Args.Net.Sample
{
    [Arguments]
    [Doc("Copy file to another location.")]
    internal class Arguments
    {
        [Argument(Name = "<source_file>", Required = true, Position = 0)]
        [Doc("Source file name.")]
        public string? SourceFile { get; set; }

        [Argument(Name = "<destination_file>", Required = true, Position = 1)]
        [Doc("Destination file name.")]
        public string? DestinationFile { get; set; }


        [Option(Name = "quiet", Required = false, ShortcutName = "q")]
        [Doc("Don't ask for confirmation.")]
        public bool? Quiet { get; set; } = false;

        [Option(Name = "retry", Required = false)]
        [Doc("Number of retries.")]
        public int? Retry { get; set; } = 0;
    }
}
```

Application:

```cs
namespace TW.Args.Net.Sample
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return new ArgumentsParser().Run<Arguments>(args, (arguments) =>
            {
                Console.WriteLine($"SourceFile = {arguments.SourceFile}, DestinationFile = {arguments.DestinationFile}, Quiet = {arguments.Quiet}, Retry = {arguments.Retry}");
                return 0;
            });
        }
    }
}
```

## Syntax variants

Syntax variants should be used when an application accepts multiple argument sets, each with different positional arguments and/or options.

### Example
`myApp` works with files and accepts the following arguments:

```
myApp copy <src_file> <dest_file> [--quiet | -q] [--retry=N]
myApp delete <file> [--force | -f]
```

In this case, the parameters for the `copy` and `delete` operations differ, making it impossible to define them within a single argument definition class. Therefore, two such classes are defined - one for the `copy` command and one for the `delete` command:

```cs
namespace TW.Args.Net.SampleVariants
{
    [Arguments]
    [Doc("Copies a source file to the destination.")]
    internal class CopyArguments
    {
        [Argument(Name = "copy", Required = true, RequiredValue = "copy", Position = 0)]
        [Doc("Copy command.")]
        public string? Action { get; set; }

        [Argument(Name = "<source_file>", Required = true, Position = 1)]
        [Doc("Source file name.")]
        public string? SourceFile { get; set; }

        [Argument(Name = "<destination_file>", Required = true, Position = 2)]
        [Doc("Destination file name.")]
        public string? DestinationFile { get; set; }


        [Option(Name = "quiet", Required = false, ShortcutName = "q")]
        [Doc("Don't ask for confirmation.")]
        public bool? Quiet { get; set; } = false;

        [Option(Name = "retry", Required = false)]
        [Doc("Number of retries.")]
        public int? Retry { get; set; } = 0;
    }
}

namespace TW.Args.Net.SampleVariants
{
    [Arguments]
    [Doc("Deletes a file.")]
    internal class DeleteArguments
    {
        [Argument(Name = "delete", Required = true, RequiredValue = "delete", Position = 0)]
        [Doc("Delete command.")]
        public string? Action { get; set; }

        [Argument(Name = "<file>", Required = true, Position = 1)]
        [Doc("File name.")]
        public string? File { get; set; }


        [Option(Name = "force", Required = false, ShortcutName = "f")]
        [Doc("Force file deletion.")]
        public bool? Force { get; set; } = false;
    }
}
```

Application:

```cs
namespace TW.Args.Net.SampleVariants
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return new ArgumentsParser().Run(args, (arguments) =>
                {
                    if (arguments is CopyArguments copyArguments) return Copy(copyArguments);
                    if (arguments is DeleteArguments deleteArguments) return Delete(deleteArguments);
                    return 3;
                });
        }

        static int Copy(CopyArguments arguments)
        {
            Console.WriteLine($"Action = {arguments.Action}, SourceFile = {arguments.SourceFile}, DestinationFile = {arguments.DestinationFile}, Quiet = {arguments.Quiet}, Retry = {arguments.Retry}");
            return 0;
        }

        static int Delete(DeleteArguments arguments)
        {
            Console.WriteLine($"Action = {arguments.Action}, File = {arguments.File}, Force = {arguments.Force}");
            return 0;
        }

    }
}
```


## Multiple option values

Normally, each option represent a single value. It is, however, possible to use multiple value of the same option when necessary. To do so, just declare the option of one of supported `List<T>` types - see [Argument definition class](#argument-definition-class) chapter.

### Example

`myApp` application is a command-line app which accepts a single error file and multiple input files:

```
myApp --err=<error_file> --in=<input_file_1> --in=<input_file_2> ...
```

Argument definition class:

```cs
namespace TW.Args.Net.Sample
{
    [Arguments]
    [Doc("Copy file to another location.")]
    internal class Arguments
    {
        [Option(Name = "err", Required = true)]
        [Doc("Error file path.")]
        public string? ErrorFile { get; set; }

        [Option(Name = "in", Required = true)]
        [Doc("A list of input files.")]
        public List<string>? InputFiles { get; set; }
    }
}
```

Syntax examples:

```
myApp --err=\path\err.txt --in=\path\input1.txt --in=\path\input2.txt       --> correct, two input files
myApp --err=\path\err.txt --in=\path\input1.txt                             --> also correct, one input file is also enough
myApp --err=\path\err.txt                                                   --> error, at least one input file is required
myApp --err=\path\err.txt --err=\path\err2.txt --in=\path\input1.txt        --> error, two error files are not accepted 
```



# Advanced topics

## `ArgumentsParser.Run()`

Runs the parser. Available in two variants:

1. Simple syntax; `T` is the type of argument definition class:
```cs
public int Run<T>(
	string[] args, 
	Func<T, int> handler, 
	Func<int>? onHelpRequested = null, 
	Func<string, int>? onSyntaxError = null, 
	Func<Exception, int>? onError = null)
```

2. Syntax variants:
```cs
public int Run(
	string[] args, 
	Func<object, int> handler, 
	Func<int>? onHelpRequested = null, 
	Func<string, int>? onSyntaxError = null, 
	Func<Exception, int>? onError = null)
```

* `args` - An array of arguments received by the application.
* `handler` - A function that receives parsed arguments. This is the heart of the application, all further processing starts here when argumenents are successfully parsed.
* `onHelpRequested` - An optional function for overriding the default behavior for help text display.
* `onSyntaxError` - An optional function for overriding the reaction on syntax error. It receives the error message in `string` parameter.
* `onError` - An optional function for overriding the reaction on any other error. It receives the error in `Exception` parameter.

In both variants the returned value should be the error code returned by the application.

## Configuring the parser

`ArgumentsParser` default configuration can be changed by passing appropriate parameters to the parser's constructor:

```cs
[Obsolete]
public ArgumentsParser(
	Assembly? assembly,
	ParserOptions? options = null)

public ArgumentsParser(
	IEnumerable<Type>? types = null,
	ParserOptions? options = null)

```

Parameters:
* `assembly` - The assembly in which argument definition classes are defined.
* `types` - A list of argument types to include in parsing.
* `options` - Parser options:
	- `ApplicationName` - The application name to use in help text. By default, the entry assembly name is used.
	- `OptionPrefix` - The option prefix. The default value is `--` (double hyphen characters).
	- `OptionShortcutPrefix` - The option shortcut prefix. The default value is `-` (single hyphen character).

> [!WARNING]
> `ArgumentParser(assembly, options)` variant is deprecated and should not be used. It will be removed in the future.
> Instead of `ArgumentParser(assembly, options)` use the equivalent `ArgumentParser(types: Arguments.GetAll(assembly), options)`.

If neither `assembly`, nor `types` are provided, then all argument definition classes found in all assemblies loaded at the moment of parsing are used.

The `types` parameter is usefull in the following scenarios:
* When argument definition classes are defined in other assemblies that are not yet loaded at the moment of parsing.
* When some argument definition classes are intentionally excluded from parsing (i.e., testing).

### Example

The example shows how to change the default option prefix from `--` to `**`.

```cs
var options = new ParserOptions()
{
	OptionPrefix = "**"
};
var result = ArgumentsParser(options: options)
	.Run(args), (arguments) =>
	{
		return 0;
	});
```

## Changing default arguments processing flow

By default, arguments are processed by one of `ArgumentsParser.Run()` methods and produce the following result:
* If option `--help` or `-h` is provided, the help text is displayed and error code 0 is returned.
* If provided arguments/options do not match any of argument definition classes, then the appropriate error message is displayed and error code 1 is returned.
* If arguments are correctly parsed, then the error code returned from the `handler` function is returned. It should be 0 on success, and some other value on failure.

It is possible to overwrite the default behavior by using custom error handlers with `ArgumentsParser.Run()`:
* When `onHelpRequested` handler is used with `Run()`, then it is executed instead of the default handler.
* When `onSyntaxError` handler is used with `Run()`, then it is executed instead of the default handler. The handler accepts a `string` paramter, which contains the error message.
* When `onError` handler is used with `Run()`, then it is executed instead of the default handler. The handler accepts a parameter of type `Exception`.

### Example

The example illustrates using of all types of error handlers.

```cs
var result = new ArgumentsParser().Run<SamplePositionalArguments>(args), 
	(arguments) =>
	{
		throw new ApplicationException("Test exception")
	},
	onHelpRequested: () =>
	{
		// --help or -h option was provided as argument
		return 97;
	},
	onSyntaxError: (message) =>
	{
		// message is string and contains a descriptive syntax error message
		return 98;
	},
	onError: (exception) =>
	{
		// exception is of type ApplicationException, exception. The message is 'Test exception'.
		return 99;
	}
);
```

## The help text generator

The help text generator is implemented in `ArgumentsHelp` class. Its constructor accepts the following optional parameters:

```cs
[Obsolete]
public ArgumentsHelp(
	Assembly? assembly, 
	ParserOptions? options = null)

public ArgumentsHelp(
	IEnumerable<Type>? types = null,
	ParserOptions? options = null)
```

* `assembly` - The assembly in which argument definition classes are defined.
* `types` - A list of argument types to include in parsing.
* `options` - Parser options. Values passed here must be consistent with the parser.

> [!WARNING]
> `ArgumentParser(assembly, options)` variant is deprecated and should not be used. It will be removed in the future.
> Instead of `ArgumentParser(assembly, options)` use the equivalent `ArgumentParser(types: Arguments.GetAll(assembly), options)`.

If neither `assembly`, nor `types` are provided, then all argument definition classes found in all assemblies loaded at the moment of parsing are used.

To display the help, use the following code snippet (arguments provided in `ArgumentsHelp` constructors should be consistent with those in `ArgumentsParser` constructor):

```cs
Console.WriteLine(new ArgumentsHelp().GetText());
```

### Example

The help text generated for the simple syntax sample:

```
SYNTAX:

TW.Args.Net.Sample <source_file> <destination_file> [--quiet] [--retry=<int32>]

    Copy file to another location.

    <source_file>        Source file name.

    <destination_file>   Destination file name.

    -q  --quiet          Don't ask for confirmation.

        --retry=<int32>  Number of retries.
```
