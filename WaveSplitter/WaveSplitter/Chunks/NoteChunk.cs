using System;

namespace WaveSplitter
{
    public class NoteChunk : ChunkBase
    {
        public NoteChunk(ref byte[] binary)
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
