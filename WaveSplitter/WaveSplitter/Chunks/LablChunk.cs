using System;

namespace WaveSplitter
{
    public class LablChunk : ChunkBase
    {
        public LablChunk(ref byte[] binary)
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
