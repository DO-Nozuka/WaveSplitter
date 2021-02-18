using System;
using System.Collections.Generic;
using System.IO;

namespace WaveSplitter
{
    static class WaveSplitter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="inputOptions"></param>
        /// <returns></returns>
        public static List<WaveFile> SplitWaves(string filePath, InputOptions inputOptions, int SilenceDecisionLevel = 0)
        {
            WaveFile wave = new WaveFile(ReadBinaryFromPath(filePath));

            return SplitWaves(wave, inputOptions, SilenceDecisionLevel);
        }
        public static List<WaveFile> SplitWaves(WaveFile waveFile, InputOptions inputOptions, int SilenceDecisionLevel = 0)
        {
            List<WaveFile> result = new List<WaveFile>();

            //---------------- カットする箇所の決定 ----------------
            List<List<Int32>> record = waveFile.GetDataRecord();
            
            //[0]にsIndex, [1]にLengthを格納
            List<int>[] sIndexLengthPair = new List<int>[2];
            sIndexLengthPair[0] = new List<int>();
            sIndexLengthPair[1] = new List<int>();

            int silenceCount = 0;
            int sIndex = 0;
            for(int index = 0; index < record[0].Count; index++)
            {
                //Threshold以下か確認
                bool IsSilence = true;
                for(int channel = 0; channel < record.Count; channel++)
                {
                    if (Math.Abs(record[channel][index]) > inputOptions.ThresholdLevel)
                        IsSilence = false;
                }

                if (IsSilence)
                {
                    silenceCount++;
                }
                else
                {
                    if (silenceCount > inputOptions.ThresholdTime)
                    {                        
                        sIndexLengthPair[0].Add(sIndex);
                        sIndexLengthPair[1].Add(index - sIndex);
                        sIndex = index + 1;
                    }
                    silenceCount = 0;
                }
            }

            sIndexLengthPair[0].Add(sIndex);
            sIndexLengthPair[1].Add(record[0].Count - 1 - sIndex);

            //---------------- ----------------

            for(int i = 0; i < sIndexLengthPair[0].Count; i++)
            {
                result.Add(waveFile.GetSplitFile(sIndexLengthPair[0][i], sIndexLengthPair[1][i]));
            }

            return result;
        }


        /// <summary>
        /// ファイルパスからファイルを読み込む
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static byte[] ReadBinaryFromPath(string filePath)
        {
            byte[] result;
            try
            {
                result = File.ReadAllBytes(filePath);
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }
    }
}
