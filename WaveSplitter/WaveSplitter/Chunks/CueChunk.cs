using System;

namespace WaveSplitter
{
    public class CueChunk : ChunkBase
    {
        public CueChunk(ref byte[] binary)
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
