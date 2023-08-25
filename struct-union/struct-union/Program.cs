using System;

namespace struct_union
{
    public class Program
    {
        static void Main(string[] args)
        {
            @struct s = new @struct();

            s.vol = 42;
        }

        struct @struct
        {
            public uint vol;
            public struct2 adr;

            public struct struct2
            {
                public uint vol2;
                public uint vol3;
                public uint vol4;
                public uint vol5;
                public uint vol6;
                public uint vol7;
            }
        }
    }
}
