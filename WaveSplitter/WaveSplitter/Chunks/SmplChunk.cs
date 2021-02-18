using System;

namespace WaveSplitter
{
    public class SmplChunk : ChunkBase
    {
        public SmplChunk(ref byte[] binary)
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
