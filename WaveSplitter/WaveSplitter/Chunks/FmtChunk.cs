using System;
using System.Linq;

namespace WaveSplitter
{
    public class FmtChunk : ChunkBase
    {
        byte[] _FormatId = new byte[2];
        byte[] _ChannelNum = new byte[2]; //チャンネル数  モノラル ならば 1(01 00)、 ステレオ ならば 2(02 00)
        byte[] _SamplingRate = new byte[4];  //サンプリングレート 	44.1kHz ならば 44100(44 AC 00 00)
        byte[] _DataSpeed = new byte[4];    //データ速度(Byte/sec)    44.1kHz 16bitステレオならば 44100×2×2=176400(10 B1 02 00)
        byte[] _BlockSize = new byte[2];// byte ブロックサイズ(Byte/sample×チャンネル数)    16bit ステレオ ならば 2×2 = 4(04 00)
        byte[] _BitRate = new byte[2];// byte サンプルあたりのビット数(bit/sample)   WAV フォーマットでは 8bit か 16bit。16bit ならば 16(10 00)

        public int FormatId { get { return BitConverter.ToInt16(_FormatId, 0); } }
        public int ChannelNum { get { return BitConverter.ToInt16(_ChannelNum, 0); } }
        public int SamplingRate { get { return BitConverter.ToInt32(_SamplingRate, 0); } }
        public int DataSpeed { get { return BitConverter.ToInt32(_DataSpeed, 0); } }
        public int BlockSize { get { return BitConverter.ToInt16(_BlockSize, 0); } }
        public int BitRate { get { return BitConverter.ToInt16(_BitRate, 0); } }

        public FmtChunk(ref byte[] binary)
        {
            byte[] chunkData = ReadChunkHeadder(ref binary);

            Array.Copy(chunkData, 0, _FormatId, 0, 2);
            Array.Copy(chunkData, 2, _ChannelNum, 0, 2);
            Array.Copy(chunkData, 4, _SamplingRate, 0, 4);
            Array.Copy(chunkData, 8, _DataSpeed, 0, 4);
            Array.Copy(chunkData, 12, _BlockSize, 0, 2);
            Array.Copy(chunkData, 14, _BitRate, 0, 2);
        }

        protected override bool GetIsCorrectFormat()
        {
            //fmtチャンクヘッダー
            if (!ChunkId.Equals("fmt ")) return false;

            //fmtチャンクサイズ
            if (Data.Length != 16) return false;

            //フォーマットID
            if (FormatId != 1) return false;

            //チャンネル数
            if (!(ChannelNum == 1 || ChannelNum == 2)) return false;

            //サンプリングレート (SoundEngine参照)
            if (!(SamplingRate == 4000
                || SamplingRate == 8000
                || SamplingRate == 11025
                || SamplingRate == 16000
                || SamplingRate == 22050
                || SamplingRate == 32000
                || SamplingRate == 44100
                || SamplingRate == 48000
                || SamplingRate == 88200
                || SamplingRate == 96000
                || SamplingRate == 176400
                || SamplingRate == 192000
                )) return false;

            //データスピード
            int CompDataSpeed = SamplingRate * ChannelNum * BitRate / 8;
            if (DataSpeed != CompDataSpeed) return false;

            //ブロックサイズ
            int CompBlockSize = BitRate / 8 * ChannelNum;
            if (BlockSize != CompBlockSize) return false;

            //ビットレート
            if (!(BitRate == 8
                || BitRate == 16
                || BitRate == 24
                || BitRate == 32
                )) return false;
            return true;
        }

        protected override byte[] GetData()
        {
            byte[] result = new byte[16];

            Array.Copy(_FormatId, 0, result, 0, 2);
            Array.Copy(_ChannelNum, 0, result, 2, 2);
            Array.Copy(_SamplingRate, 0, result, 4, 4);
            Array.Copy(_DataSpeed, 0, result, 8, 4);
            Array.Copy(_BlockSize, 0, result, 12, 2);
            Array.Copy(_BitRate, 0, result, 14, 2);

            return result;
        }
    }
}
