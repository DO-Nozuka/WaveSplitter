using System;

namespace WaveSplitter
{
    public class PlstChunk : ChunkBase
    {
        public PlstChunk(ref byte[] binary)
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
