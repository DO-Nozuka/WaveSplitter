using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveSplitter
{
    public class WaveFileChunks
    {
        //fmt  チャンク(必須)
        //data チャンク（必須）
        //fact チャンク（オプション）
        //cue  チャンク（オプション）
        //plst チャンク（オプション）
        //list チャンク（オプション）
        //labl チャンク（オプション）
        //note チャンク（オプション）
        //ltxt チャンク（オプション）
        //smpl チャンク（オプション）
        //inst チャンク（オプション） 
        public FmtChunk Fmt = null;
        public NewDataChunk Data = null;
        public FactChunk Fact = null;
        public CueChunk Cue = null;
        public PlstChunk Plst = null;
        public ListChunk List = null;
        public LablChunk Labl = null;
        public NoteChunk Note = null;
        public LtxtChunk Ltxt = null;
        public SmplChunk Smpl = null;
        public InstChunk Inst = null;
        public JunkChunk Junk = null;


        public WaveFileChunks(ref byte[] _tmpBinary)
        {
            while (_tmpBinary.Length != 0)
            {
                ChunkType chunkType = GetChunkType(_tmpBinary);

                switch (chunkType)
                {
                    case ChunkType.Fmt:
                        Fmt = new FmtChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Data:
                        Data = new NewDataChunk(ref _tmpBinary, Fmt);
                        break;
                    case ChunkType.Fact:
                        Fact = new FactChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Cue:
                        Cue = new CueChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Plst:
                        Plst = new PlstChunk(ref _tmpBinary);
                        break;
                    case ChunkType.List:
                        List = new ListChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Labl:
                        Labl = new LablChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Note:
                        Note = new NoteChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Ltxt:
                        Ltxt = new LtxtChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Smpl:
                        Smpl = new SmplChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Inst:
                        Inst = new InstChunk(ref _tmpBinary);
                        break;
                    case ChunkType.Junk:
                        Junk = new JunkChunk(ref _tmpBinary);
                        break;
                    default:
                        throw new FileFormatException();
                }
            }
        }
        public WaveFileChunks(List<ChunkBase> chunks)
        {
            foreach (ChunkBase chunk in chunks)
            {
                switch (chunk.ChunkId)
                {
                    case "fmt ":
                        Fmt = (FmtChunk)chunk;
                        break;
                    case "data":
                        Data = (NewDataChunk)chunk;
                        break;
                    case "fact":
                        Fact = (FactChunk)chunk;
                        break;
                    case "LIST":
                        List = (ListChunk)chunk;
                        break;
                    case "cue ":
                        Cue = (CueChunk)chunk;
                        break;

                    //TODO
                    //plst チャンク（オプション）
                    //labl チャンク（オプション）
                    //note チャンク（オプション）
                    //ltxt チャンク（オプション）
                    //smpl チャンク（オプション）
                    //inst チャンク（オプション） 

                    case "JUNK":
                        Junk = (JunkChunk)chunk;
                        break;

                    default:
                        break;
                }
            }
        }
        


        /// <summary>
        /// フォーマットを確認する
        /// </summary>
        /// <returns>正しいフォーマットかどうか</returns>
        public bool IsCorrectFormat()
        {
            List<ChunkBase> tmpChunks = GetChunks();

            foreach (ChunkBase chunk in tmpChunks)
            {
                if (chunk == null) return false;
                if (!chunk.IsCorrectFormat) return false;
            }

            return true;
        }


        private ChunkType GetChunkType(byte[] binary)
        {
            ChunkType result = ChunkType.None;

            byte[] _ChunkName = new byte[4];
            Array.Copy(binary, 0, _ChunkName, 0, 4);

            string ChunkName = Encoding.ASCII.GetString(_ChunkName);

            switch (ChunkName)
            {
                case "fmt ":
                    result = ChunkType.Fmt;
                    break;
                case "data":
                    result = ChunkType.Data;
                    break;
                case "fact":
                    result = ChunkType.Fact;
                    break;
                case "LIST":
                    result = ChunkType.List;
                    break;
                case "cue ":
                    result = ChunkType.Cue;
                    break;

                //TODO
                //plst チャンク（オプション）
                //labl チャンク（オプション）
                //note チャンク（オプション）
                //ltxt チャンク（オプション）
                //smpl チャンク（オプション）
                //inst チャンク（オプション） 

                case "JUNK":
                    result = ChunkType.Junk;
                    break;

                default:
                    result = ChunkType.None;
                    break;
            }

            return result;
        }

        /// <summary>
        /// チャンクデータのサイズを取得する
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            List<ChunkBase> Chunks = GetChunks();

            int result = 0;
            foreach (ChunkBase chunk in Chunks)
            {
                result += chunk.ChunkSize;
            }

            return result;
        }

        public byte[] GetBytes()
        {
            List<ChunkBase> Chunks = GetChunks();

            byte[] result = new byte[GetSize()];
            int index = 0;
            foreach (ChunkBase chunk in Chunks)
            {
                Array.Copy(chunk.Binary, 0, result, index, chunk.Binary.Length);
                index += chunk.Binary.Length;
            }

            return result;
        }

        /// <summary>
        /// Chunksを受け取る
        /// </summary>
        /// <returns></returns>
        private List<ChunkBase> GetChunks()
        {
            List<ChunkBase> result = new List<ChunkBase>();

            //fmt  チャンク(必須)
            if (Fmt != null) result.Add(Fmt);
            //data チャンク（必須）
            if (Data != null) result.Add(Data);
            //fact チャンク（オプション）
            if (Fact != null) result.Add(Fact);
            //cue  チャンク（オプション）
            if (Cue != null) result.Add(Cue);
            //plst チャンク（オプション）
            if (Plst != null) result.Add(Plst);
            //list チャンク（オプション）
            if (List != null) result.Add(List);
            //labl チャンク（オプション）
            if (Labl != null) result.Add(Labl);
            //note チャンク（オプション）
            if (Note != null) result.Add(Note);
            //ltxt チャンク（オプション）
            if (Ltxt != null) result.Add(Ltxt);
            //smpl チャンク（オプション）
            if (Smpl != null) result.Add(Smpl);
            //inst チャンク（オプション） 
            if (Inst != null) result.Add(Inst);
            //Junk チャンク (謎)
            if (Junk != null) result.Add(Junk);

            return result;
        }
    }

    public class WaveFile
    {
        byte[] _HeaderId = new byte[4];
        byte[] _RiffDataSize
        {
            get
            {
                byte[] result = BitConverter.GetBytes(Chunks.Data.Data.Length);

                return result;
            }
        }
        byte[] _WaveId = new byte[4];
        WaveFileChunks Chunks;

        public byte[] Binary {
            get {
                byte[] result = new byte[Chunks.GetSize() + 12];

                Array.Copy(_HeaderId, 0, result, 0, 4);
                Array.Copy(_RiffDataSize, 0, result, 4, 4);
                Array.Copy(_WaveId, 0, result, 8, 4);
                var chunksBinary = Chunks.GetBytes();
                Array.Copy(chunksBinary, 0, result, 12, chunksBinary.Length);

                return result;
            }
        }

        public WaveFile(byte[] binary)
        {
            if(binary.Length < 44)
            {
                throw new FileFormatException("FileSize is too short");
            }

            //オリジナルデータのコピー
            //_Origin = new byte[binary.Length];
            //Array.Copy(binary, 0, _Origin, 0, binary.Length);

            //RIFF ID
            Array.Copy(binary, 0, _HeaderId, 0, 4);

            //RIFFデータサイズ
            //Array.Copy(binary, 4, _RiffDataSize, 0, 4);

            //WAVE ID
            Array.Copy(binary, 8, _WaveId, 0, 4);

            //チャンクデータ
            byte[] _tmpBinary = new byte[binary.Length - 12];
            Array.Copy(binary, 12, _tmpBinary, 0, binary.Length - 12);

            Chunks = new WaveFileChunks(ref _tmpBinary);

            if(IsCorrectFormat())
            {
                
            }
            else
            {
                throw new FileFormatException();
            }
        }

        private WaveFile(byte[] HeaderId, byte[] WaveId, FmtChunk fmtChunk)
        {
            _HeaderId = HeaderId;
            _WaveId = WaveId;

            var tmpChunks = new List<ChunkBase>();
            tmpChunks.Add(fmtChunk);
            Chunks = new WaveFileChunks(tmpChunks);
        }

        //public void Split(int sIndex, int eIndex)
        //{
        //    Chunks.Data.Split(sIndex, eIndex, Chunks.Fmt);
        //}

        public WaveFile GetSplitFile(int sIndex, int length)
        {
            WaveFile result = new WaveFile(this._HeaderId, this._WaveId, Chunks.Fmt);
            result.Chunks.Data = this.Chunks.Data.GetSplitChunk(sIndex, length);
            
            return result;
        }

        public bool IsCorrectFormat()
        {
            // RIFF ヘッダー(必須)
            if (!Encoding.ASCII.GetString(_HeaderId).Equals("RIFF")) return false;
            if (!Encoding.ASCII.GetString(_WaveId).Equals("WAVE")) return false;
            if (!Chunks.IsCorrectFormat()) return false;

            return true;
        }

        public List<List<Int32>> GetDataRecord()
        {
            return Chunks.Data.Record;
        }
    }
}
