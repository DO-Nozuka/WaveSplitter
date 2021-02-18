using System;

namespace WaveSplitter
{
    public class FactChunk : ChunkBase
    {
        public FactChunk(ref byte[] binary)
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
