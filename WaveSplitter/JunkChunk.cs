using System;

namespace WaveSplitter
{
    public class JunkChunk : ChunkBase
    {
        public JunkChunk(ref byte[] binary)
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