using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace A6

{
    #region Structures
    public struct TypeOfSize5
    {
        //5 Bytes
        public byte byte1;
        public byte byte2;
        public byte byte3;
        public byte byte4;
        public byte byte5;
        
    }
    public struct TypeOfSize8
    {
        TypeOfSize5 bytes5;
        byte byte0;
        byte byte1;
        byte byte2;
    }
    public struct TypeOfSize16
    {
        TypeOfSize8 bytes8_0;
        TypeOfSize8 bytes8_1;
    }
    public struct TypeOfSize22
    {
        TypeOfSize5 bytes5_0;
        TypeOfSize5 bytes5_1;
        TypeOfSize5 bytes5_2;
        TypeOfSize5 bytes5_3;
        byte byte1;
        byte byte2;
    }
    public struct TypeOfSize32
    {
        TypeOfSize16 bytes16_0;
        TypeOfSize16 bytes16_1;
    }
    public struct TypeOfSize64
    {
        TypeOfSize32 bytes32_0;
        TypeOfSize32 bytes32_1;
    }
    public struct TypeOfSize125
    {
        //Bytes 110
        TypeOfSize22 size1;
        TypeOfSize22 size2;
        TypeOfSize22 size3;
        TypeOfSize22 size4;
        TypeOfSize22 size5;
        //15 Bytes
        TypeOfSize5 size6;
        TypeOfSize5 size7;
        TypeOfSize5 size8;
    }
    public struct TypeOfSize128
    {
        TypeOfSize64 bytes64_0;
        TypeOfSize64 bytes64_1;
    }
    public struct TypeOfSize256
    {
        TypeOfSize128 bytes_0;
        TypeOfSize128 bytes_1;
    }
    public struct TypeOfSize512
    {
        TypeOfSize256 byte256_0;
        TypeOfSize256 byte256_1;
    }
    public struct TypeOfSize1024
    {
        TypeOfSize512 bytes512_0;
        TypeOfSize512 bytes512_1;
    }
    public struct TypeOfSize2048
    {
        TypeOfSize1024 bytes1024_0;
        TypeOfSize1024 bytes1024_1;
    }
    public struct TypeOfSize4096
    {
        TypeOfSize2048 bytes2048_0;
        TypeOfSize2048 bytes2048_1;
    }
    public struct TypeOfSize8192
    {
        TypeOfSize4096 bytes4096_0;
        TypeOfSize4096 bytes4096_1;
    }
    public struct TypeOfSize16384
    {
        TypeOfSize8192 bytes8192_0;
        TypeOfSize8192 bytes8192_1;
    }
    public struct TypeOfSize32768
    {
        TypeOfSize16384 bytes16384_0;
        TypeOfSize16384 bytes16384_1;
    }
    public struct TypeOfSize65536
    {
        TypeOfSize32768 bytes32768_0;
        TypeOfSize32768 bytes32768_1;
    }
    public struct TypeOfSize131072 {
        TypeOfSize65536 bytes655536_0;
        TypeOfSize65536 bytes655536_1;
    }
    public struct TypeOfSize262144
    {
        TypeOfSize131072 bytes131072_0;
        TypeOfSize131072 bytes131072_1;
    }
    public struct TypeOfSize512288
    {
        //512000 Bytes
        TypeOfSize262144 kb256;
        TypeOfSize131072 kb128;
        TypeOfSize65536 kb65;
        TypeOfSize32768 kb32;
        TypeOfSize16384 kb16;
        TypeOfSize4096 kb4;
        //250 Bytes
        TypeOfSize125 bytes125_0;
        TypeOfSize125 bytes125_1;
        //22 Bytes
        TypeOfSize22 bytes22;
        //15 Bytes
        TypeOfSize5 bytes5_0;
        TypeOfSize5 bytes5_1;
        TypeOfSize5 bytes5_2;
        //1 Byte
        byte byte0;
    }
    #endregion

    #region MaxStackOfDepthMethods
    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize32768 kb32;
        TypeOfSize8192 kb8;
        TypeOfSize4096 kb4;
    }
    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize4096 kb4;
        TypeOfSize512 bytes512;
        TypeOfSize256 bytes256;
        TypeOfSize125 bytes125;
        TypeOfSize22 bytes22;
        TypeOfSize16 bytes16;
    }
    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize256 bytes256;
        TypeOfSize128 bytes128;
        TypeOfSize32 bytes32_0;
        TypeOfSize16 bytes16_0;
        TypeOfSize22 bytes22;
        TypeOfSize16 bytes16;
    }
    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize64 bytes64;
        TypeOfSize32 bytes32;
        TypeOfSize16 bytes16;
        TypeOfSize8 bytes8;
        TypeOfSize5 bytes5;
        byte byte0;
        byte byte1;
        byte byte2;
    }
    #endregion

    #region Write On Heap Class
    public class TypeWithMemoryOnHeap{
        private List<List<int>> MemoryList;
        public void Allocate()
        {
            MemoryList = new List<List<int>>();
            for(int i = 0; i < 55000; i++)
            {
                List<int> mustAddedList = new List<int>
                {
                    1, 2, 3, 4, 5, 6, 7, 8
                };
                MemoryList.Add(mustAddedList);
            }
        }
        public void DeAllocate()
        {
            MemoryList = null;
        }
    }
    #endregion

    #region Struct Or Class
    public struct StructOrClass1
    {
        public int X;
    }
    public class StructOrClass2
    {
        public int X;
    }
    public struct StructOrClass3
    {
        public StructOrClass2 X;
    }
    #endregion
    
    public enum FutureHusbandType : int
    {
        None = 0,
        IsBald = 1,
        IsShort = 2,
        HasBigNose = 4
    }
    
    public class Program
    {
        public static int GetObjectType(object o)
        {
            if (o is string || o is null) return 0;
            if (o is int[]) return 1;
            if (o is int) return 2;
            return -1;
        }
        public static bool IdealHusband(FutureHusbandType fht)
        {
            int allFutures = (int)((fht & FutureHusbandType.HasBigNose) | 
                (fht & FutureHusbandType.IsBald) |
                (fht & FutureHusbandType.IsShort));

            if (allFutures == 2 || allFutures == 4 || 
                allFutures == 0 || allFutures == 1)
                return false;
            if(allFutures == (int)(FutureHusbandType.IsBald | FutureHusbandType.IsShort) ||
                allFutures == (int)(FutureHusbandType.IsBald | FutureHusbandType.HasBigNose)||
                allFutures == (int)(FutureHusbandType.IsShort | FutureHusbandType.HasBigNose))
                    return  true;
            if (allFutures == 7)
                return false;
            return true;
        }
            
        static void Main(string[] args)
        {
        }
        
    }
}
