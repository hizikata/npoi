﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.Util;
using System.IO;

namespace TestCases.OpenXml4Net
{
    public class OpenXml4NetTestDataSamples
    {
        private static POIDataSamples _samples = POIDataSamples.GetOpenXml4NetInstance();

        private OpenXml4NetTestDataSamples()
        {
            // no instances of this class
        }

        public static Stream OpenSampleStream(String sampleFileName)
        {
            return _samples.OpenResourceAsStream(sampleFileName);
        }
        public static String GetSampleFileName(String sampleFileName)
        {
            return new FileInfo(_samples.ResolvedDataDir+sampleFileName).FullName;
        }

        public static FileInfo GetSampleFile(String sampleFileName)
        {
            return new FileInfo(sampleFileName);
        }

        public static FileInfo GetOutputFile(String outputFileName)
        {
            String suffix = outputFileName.Substring(outputFileName.LastIndexOf('.'));
            return new FileInfo(TempFile.GetTempFilePath(outputFileName, suffix));
        }


        public static Stream OpenComplianceSampleStream(String sampleFileName)
        {
            return _samples.OpenResourceAsStream(sampleFileName);
        }
    }
}
