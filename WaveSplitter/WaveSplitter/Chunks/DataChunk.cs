using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Authentication.ExtendedProtection;

namespace WaveSplitter
{

    public class NewDataChunk : ChunkBase
    {
        private FmtChunk fmtChunk;

        /// <summary>
        /// DataArray[channel][index]で参照する
        /// DataArray[channel].Add(int32 data)でデータを追加する
        /// 基本は channel = 0 はL
        /// channel = 1 はR を表す
        /// </summary>
        public List<List<Int32>> Record { get; private set; } = new List<List<Int32>>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="binary">データチャンク(ヘッダー含む)のバイナリデータ</param>
        /// <param name="fmtChunk"></param>
        public NewDataChunk(ref byte[] binary, FmtChunk fmtChunk)
        {
            byte[] tmpChunkData = ReadChunkHeadder(ref binary);

            this.fmtChunk = fmtChunk;

            //レコードの初期化
            for (int i = 0; i < fmtChunk.ChannelNum; i++)
                Record.Add(new List<int>());

            int ByteRate = fmtChunk.BitRate / 8;
            byte[] tmp = new byte[ByteRate];
            for (int index = 0; index < tmpChunkData.Length;)
            {
                for (int channel = 0; channel < fmtChunk.ChannelNum; channel++)
                {
                    Array.Copy(tmpChunkData, index, tmp, 0, ByteRate);

                    Record[channel].Add(ByteToIntN(tmp));
                    index += ByteRate;
                }
            }
        }

        private NewDataChunk(List<List<Int32>> Record, FmtChunk fmtChunk)
        {
            _ChunkId[0] = (byte)'d';
            _ChunkId[1] = (byte)'a';
            _ChunkId[2] = (byte)'t';
            _ChunkId[3] = (byte)'a';
            this.Record = Record;
            this.fmtChunk = fmtChunk;
        }

        public NewDataChunk GetSplitChunk(int sIndex, int length)
        {
            List<List<Int32>> splitRecord = new List<List<int>>();
            for(int channel = 0; channel < fmtChunk.ChannelNum; channel++)
            {
                splitRecord.Add(Record[channel].GetRange(sIndex, length));
            }
            
            return new NewDataChunk(splitRecord, fmtChunk);
        }

        protected override byte[] GetData()
        {
            List<byte> result = new List<byte>();

            for (int index = 0; index < Record[0].Count; index++)
            {
                for (int channel = 0; channel < fmtChunk.ChannelNum; channel++)
                {
                    var bytes = IntNToByteArray(Record[channel][index], fmtChunk.BitRate);
                    foreach (byte val in bytes)
                        result.Add(val);
                }
            }

            return result.ToArray();
        }

        protected override bool GetIsCorrectFormat()
        {
            //TODO:てきとー
            return Record[0] != null;
        }



        private Int32 ByteToIntN(byte[] binary)
        {
            Int32 result = 0;

            switch (binary.Length * 8)
            {
                case 8:
                    result = binary[0];
                    break;
                case 16:
                    result = BitConverter.ToInt16(binary, 0);
                    break;
                case 24:
                    //TODO 24ビットの変換を実装する
                    throw new NotImplementedException();
                case 32:
                    result = BitConverter.ToInt32(binary, 0);
                    break;
            }
            return result;
        }

        private byte[] IntNToByteArray(Int32 value, int N)
        {
            switch (N)
            {
                case 8:
                    char tmpChar = (char)value;
                    return BitConverter.GetBytes(tmpChar);
                case 16:
                    Int16 tmpInt16 = (Int16)value;
                    return BitConverter.GetBytes(tmpInt16);
                case 24:
                    throw new NotImplementedException();
                case 32:
                    Int32 tmpInt32 = (Int32)value;
                    return BitConverter.GetBytes(tmpInt32);
                default:
                    throw new Exception();
            }
        }
    }

    //public class DataChunk : ChunkBase
    //{
    //    Int32[] _LDataArray;
    //    Int32[] _RDataArray;


    //    public Int32[] LDataArray { get { return _LDataArray; } }
    //    public Int32[] RDataArray { get { return _RDataArray; } }

    //    public Int32 this[int channel, int index]
    //    {
    //        get
    //        {
    //            if (channel == 0) return _LDataArray[index];
    //            if (channel == 1) return _RDataArray[index];
    //            return -1;
    //        }
    //    }

    //    public int Length { get => _LDataArray.Length; }
        

    //    public DataChunk(ref byte[] binary, FmtChunk format) : base(ref binary)
    //    {
    //        int DataSizeInByte = format.BitRate / 8;

    //        if (format.ChannelNum == 1)
    //        {
    //            _LDataArray = new Int32[ChunkData.Length / DataSizeInByte];
    //        }
    //        else if(format.ChannelNum == 2)
    //        {
    //            _LDataArray = new Int32[ChunkData.Length / DataSizeInByte / 2];
    //            _RDataArray = new Int32[ChunkData.Length / DataSizeInByte / 2];
    //        }

    //        /////////////////////////
    //        for (int i = 0; i < _LDataArray.Length; i++)
    //        {
    //            if(format.ChannelNum == 1)
    //            {
    //                _LDataArray[i] = GetImpulseData(ChunkData, i * format.BlockSize, format.BitRate);
    //            }
    //            else if (format.ChannelNum == 2)
    //            {
    //                _LDataArray[i] = GetImpulseData(ChunkData, i * format.BlockSize, format.BitRate);
    //                _RDataArray[i] = GetImpulseData(ChunkData, i * format.BlockSize + format.BitRate / 8, format.BitRate);
    //            }
    //        }
    //        ///////////////////////////


    //        return;
    //    }

    //    private Int32 GetImpulseData(byte[] binary, int index, int bitRate)
    //    {
    //        int DataSizeInByte = bitRate / 8;
    //        byte[] tmpByte = new byte[DataSizeInByte];
    //        for (int j = 0; j < DataSizeInByte; j++)
    //        {
    //            tmpByte[j] = ChunkData[index + j];
    //        }

    //        int result = 0;
    //        switch (bitRate)
    //        {
    //            case 8:
    //                result = tmpByte[0];
    //                break;
    //            case 16:
    //                result = BitConverter.ToInt16(tmpByte, 0);
    //                break;
    //            case 24:
    //                //TODO 24ビットの変換を実装する
    //                throw new NotImplementedException();
    //            case 32:
    //                result = BitConverter.ToInt32(tmpByte, 0);
    //                break;
    //        }

    //        return result;
    //    }

    //    protected override bool GetIsCorrectFormat()
    //    {
    //        //dataチャンクヘッダー
    //        if (!ChunkId.Equals("data")) return false;

    //        return true;
    //    }

    //    public void Split(int StartIndex, int EndIndex, FmtChunk fmtChunk)
    //    {
    //        Int32[] tmpNewLData = new int[EndIndex - StartIndex + 1];
    //        Array.Copy(_LDataArray, StartIndex, tmpNewLData, 0, EndIndex - StartIndex + 1);
    //        _LDataArray = tmpNewLData;

    //        if (tmpNewLData.Length != 0)
    //        {
    //            Int32[] tmpNewRData = new int[EndIndex - StartIndex + 1];
    //            Array.Copy(_RDataArray, StartIndex, tmpNewRData, 0, EndIndex - StartIndex + 1);
    //            _RDataArray = tmpNewRData;
    //        }

    //        List<byte> tmpNewDataList = new List<byte>();
    //        for (int i = 0; i < _LDataArray.Length; i++)
    //        {
    //            switch(fmtChunk.BitRate)
    //            {
    //                case 8:
    //                    char tmpChar = (char)_LDataArray[i];
    //                    byte[] tmpCharByteArray = BitConverter.GetBytes(tmpChar);
    //                    for(int j = 0; j < tmpCharByteArray.Length; j++)
    //                    {
    //                        tmpNewDataList.Add(tmpCharByteArray[j]);
    //                    }
    //                    break;
    //                case 16:
    //                    Int16 tmpInt16 = (Int16)_LDataArray[i];
    //                    byte[] tmpInt16ByteArray = BitConverter.GetBytes(tmpInt16);
    //                    for (int j = 0; j < tmpInt16ByteArray.Length; j++)
    //                    {
    //                        tmpNewDataList.Add(tmpInt16ByteArray[j]);
    //                    }

    //                    break;
    //                case 24:
    //                    throw new NotImplementedException();
    //                case 32:
    //                    Int32 tmpInt32 = (Int32)_LDataArray[i];
    //                    byte[] tmpInt32ByteArray = BitConverter.GetBytes(tmpInt32);
    //                    for (int j = 0; j < tmpInt32ByteArray.Length; j++)
    //                    {
    //                        tmpNewDataList.Add(tmpInt32ByteArray[j]);
    //                    }
    //                    break;
    //            }

    //            if (_RDataArray.Length != 0)
    //            {
    //                switch (fmtChunk.BitRate)
    //                {
    //                    case 8:
    //                        char tmpChar = (char)_RDataArray[i];
    //                        byte[] tmpCharByteArray = BitConverter.GetBytes(tmpChar);
    //                        for (int j = 0; j < tmpCharByteArray.Length; j++)
    //                        {
    //                            tmpNewDataList.Add(tmpCharByteArray[j]);
    //                        }
    //                        break;
    //                    case 16:
    //                        Int16 tmpInt16 = (Int16)_RDataArray[i];
    //                        byte[] tmpInt16ByteArray = BitConverter.GetBytes(tmpInt16);
    //                        for (int j = 0; j < tmpInt16ByteArray.Length; j++)
    //                        {
    //                            tmpNewDataList.Add(tmpInt16ByteArray[j]);
    //                        }

    //                        break;
    //                    case 24:
    //                        throw new NotImplementedException();
    //                    case 32:
    //                        Int32 tmpInt32 = (Int32)_RDataArray[i];
    //                        byte[] tmpInt32ByteArray = BitConverter.GetBytes(tmpInt32);
    //                        for (int j = 0; j < tmpInt32ByteArray.Length; j++)
    //                        {
    //                            tmpNewDataList.Add(tmpInt32ByteArray[j]);
    //                        }
    //                        break;
    //                }
    //            }
    //        }

    //        //ChunkDataの更新
    //        //for(int i = 0; i < tmpNewDataList.Count; i++)
    //        //{
    //        //    Array.Resize(ref _ChunkData, tmpNewDataList.Count);
    //        //    _ChunkData[i] = tmpNewDataList[i];
    //        //    _ChunkDataSize = BitConverter.GetBytes(tmpNewDataList.Count);
    //        //}
    //    }

    //    internal DataChunk GetSection(int sIndex, int eIndex)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override byte[] GetChunkData()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override byte[] GetBinary()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override void Initialize(byte[] chunkData)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
