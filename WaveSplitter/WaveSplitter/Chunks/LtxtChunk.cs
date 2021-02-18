using System;

namespace WaveSplitter
{
    public class LtxtChunk : ChunkBase
    {
        public LtxtChunk(ref byte[] binary)
        {

        }

        protected override byte[] GetData()
        {
            throw new NotImplementedException();
        }

        protected override bool GetIsCorrectFormat()
        {
            throw new NotImplementedException();
        }
    }
}
