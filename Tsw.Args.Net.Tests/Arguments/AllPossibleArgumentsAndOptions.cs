namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("AllPossibleArgumentsAndOptions")]
    internal class AllPossibleArgumentsAndOptions
    {
        [Argument(Name = "OAByte", Position = 0, Required = false)]
        [Doc("OAByte")]
        public byte? OAByte { get; set; }

        [Argument(Name = "OADecimal", Position = 1, Required = false)]
        [Doc("OADecimal")]
        public decimal? OADecimal { get; set; }

        [Argument(Name = "OAInt16", Position = 2, Required = false)]
        [Doc("OAInt16")]
        public short? OAInt16 { get; set; }

        [Argument(Name = "OAInt32", Position = 3, Required = false)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; }

        [Argument(Name = "OAInt64", Position = 4, Required = false)]
        [Doc("OAInt64")]
        public long? OAInt64 { get; set; }

        [Argument(Name = "OAString", Position = 5, Required = false)]
        [Doc("OAString")]
        public string? OAString { get; set; }

        [Argument(Name = "OAUInt16", Position = 6, Required = false)]
        [Doc("OAUInt16")]
        public short? OAUInt16 { get; set; }

        [Argument(Name = "OAInt32", Position = 7, Required = false)]
        [Doc("OAUInt32")]
        public int? OAUInt32 { get; set; }

        [Argument(Name = "OAInt64", Position = 8, Required = false)]
        [Doc("OAUInt64")]
        public long? OAUInt64 { get; set; }



        [Option(Name = "OOBool", Required = false, ShortcutName = "b")]
        [Doc("OOBool")]
        public bool? OOBool { get; set; }

        [Option(Name = "OOByte", Required = false)]
        [Doc("OOByte")]
        public byte? OOByte { get; set; }

        [Option(Name = "OODecimal", Required = false, ShortcutName = "d")]
        [Doc("OODecimal")]
        public decimal? OODecimal { get; set; }

        [Option(Name = "OOInt16", Required = false)]
        [Doc("OOInt16")]
        public short? OOInt16 { get; set; }

        [Option(Name = "OOInt32", Required = false, ShortcutName = "i")]
        [Doc("OOInt32")]
        public int? OOInt32 { get; set; }

        [Option(Name = "OOInt64", Required = false)]
        [Doc("OOInt64")]
        public long? OOInt64 { get; set; }

        [Option(Name = "OOString", Required = false, ShortcutName = "s")]
        [Doc("OOString")]
        public string? OOString { get; set; }

        [Option(Name = "OOUInt16", Required = false)]
        [Doc("OOUInt16")]
        public ushort? OOUInt16 { get; set; }

        [Option(Name = "OOUInt32", Required = false)]
        [Doc("OOUInt32")]
        public uint? OOUInt32 { get; set; }

        [Option(Name = "OOUInt64", Required = false)]
        [Doc("OOUInt64")]
        public ulong? OOUInt64 { get; set; }



        [Option(Name = "OOListByte", Required = false)]
        [Doc("OOListByte")]
        public List<byte>? OOListByte { get; set; }

        [Option(Name = "OOListDecimal", Required = false)]
        [Doc("OOListDecimal")]
        public List<decimal>? OOListDecimal { get; set; }

        [Option(Name = "OOListInt16", Required = false)]
        [Doc("OOListInt16")]
        public List<short>? OOListInt16 { get; set; }

        [Option(Name = "OOListInt32", Required = false)]
        [Doc("OOListInt32")]
        public List<int>? OOListInt32 { get; set; }

        [Option(Name = "OOListInt64", Required = false)]
        [Doc("OOListInt64")]
        public List<long>? OOListInt64 { get; set; }

        [Option(Name = "OOListString", Required = false)]
        [Doc("OOListString")]
        public List<string>? OOListString { get; set; }

        [Option(Name = "OOListUInt16", Required = false)]
        [Doc("OOListUInt16")]
        public List<ushort>? OOListUInt16 { get; set; }

        [Option(Name = "OOListUInt32", Required = false)]
        [Doc("OOListUInt32")]
        public List<uint>? OOListUInt32 { get; set; }

        [Option(Name = "OOListUInt64", Required = false)]
        [Doc("OOListUInt64")]
        public List<ulong>? OOListUInt64 { get; set; }

    }
}
