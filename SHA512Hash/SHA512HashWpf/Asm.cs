using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SHA512HashWpf
{
    public static class Asm
    {
        [DllImport("AsmLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Hash(int a, int b);
    }
}