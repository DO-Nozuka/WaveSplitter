using System;

namespace WaveSplitter
{
    public class InstChunk : ChunkBase
    {
        public InstChunk(ref byte[] binary)
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
