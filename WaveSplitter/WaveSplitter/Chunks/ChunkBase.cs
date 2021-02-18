using System;
using System.Linq;
using System.Text;

namespace WaveSplitter
{
    public abstract class ChunkBase
    {
        protected byte[] _ChunkId = new byte[4];

        public string ChunkId { get { return Encoding.ASCII.GetString(_ChunkId); } }
        public int ChunkSize => Data.Length + 8;
        public byte[] Header => GetHeader();
        public byte[] Data => GetData();
        public byte[] Binary => GetBinary();
        public bool IsCorrectFormat => GetIsCorrectFormat();


        protected abstract bool GetIsCorrectFormat();
        /// <summary>
        /// ヘッダー部を取得します
        /// </summary>
        /// <returns></returns>
        protected byte[] GetHeader()
        {
            byte[] result = new byte[8];

            Array.Copy(_ChunkId, result, _ChunkId.Length);
            byte[] DataLengthBytes = BitConverter.GetBytes(Data.Length);
            Array.Copy(DataLengthBytes, 0, result, 4, DataLengthBytes.Length);

            return result;
        }
        /// <summary>
        /// データ部を取得します
        /// </summary>
        /// <returns></returns>
        protected abstract byte[] GetData();
        /// <summary>
        /// ヘッダー部とデータ部をまとめて取得します
        /// </summary>
        /// <returns></returns>
        protected byte[] GetBinary()
        {
            byte[] header = Header;
            byte[] data = Data;

            return header.Concat(data).ToArray();
        }       

        protected byte[] ReadChunkHeadder(ref byte[] binary)
        {
            //ChunkIdの読み込み
            Array.Copy(binary, 0, _ChunkId, 0, 4);

            //ChunkDataSizeの読み込み
            byte[] tmpChunkDataSize = new byte[4];
            Array.Copy(binary, 4, tmpChunkDataSize, 0, 4);

            //ChunkDataの読み込み
            byte[] tmpChunkData = new byte[BitConverter.ToInt32(tmpChunkDataSize, 0)];
            Array.Copy(binary, 8, tmpChunkData, 0, tmpChunkData.Length);

            //読み込んだデータを削除してbinaryを返す
            int tmpChunkSize = tmpChunkData.Length + 8;
            int rest = binary.Length - (tmpChunkSize);
            byte[] result = new byte[rest];
            Array.Copy(binary, tmpChunkSize, result, 0, rest);

            binary = result;


            return tmpChunkData;
        }
    }
}
