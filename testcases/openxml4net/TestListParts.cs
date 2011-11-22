/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for Additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

using NPOI.Util;
using NPOI.OpenXml4Net.OPC;
using TestCases.OpenXml4Net;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace TestCases.OPC
{
    [TestClass]
    public class TestListParts
    {
        private static POILogger logger = POILogFactory.GetLogger(typeof(TestListParts));

        private Dictionary<PackagePartName, String> expectedValues;

        private Dictionary<PackagePartName, String> values;

        [TestInitialize]
        public void SetUp()
        {
            values = new Dictionary<PackagePartName, String>();

            // Expected values
            expectedValues = new Dictionary<PackagePartName, String>();
            expectedValues.Add(PackagingURIHelper.CreatePartName("/_rels/.rels"),
                    "application/vnd.Openxmlformats-namespace.relationships+xml");

            expectedValues
                    .Add(PackagingURIHelper.CreatePartName("/docProps/app.xml"),
                            "application/vnd.Openxmlformats-officedocument.extended-properties+xml");
            expectedValues.Add(PackagingURIHelper
                    .CreatePartName("/docProps/core.xml"),
                    "application/vnd.Openxmlformats-namespace.core-properties+xml");
            expectedValues.Add(PackagingURIHelper
                    .CreatePartName("/word/_rels/document.xml.rels"),
                    "application/vnd.Openxmlformats-namespace.relationships+xml");
            expectedValues
                    .Add(
                            PackagingURIHelper.CreatePartName("/word/document.xml"),
                            "application/vnd.Openxmlformats-officedocument.wordProcessingml.document.main+xml");
            expectedValues
                    .Add(PackagingURIHelper.CreatePartName("/word/fontTable.xml"),
                            "application/vnd.Openxmlformats-officedocument.wordProcessingml.fontTable+xml");
            expectedValues.Add(PackagingURIHelper
                    .CreatePartName("/word/media/image1.gif"), "image/gif");
            expectedValues
                    .Add(PackagingURIHelper.CreatePartName("/word/settings.xml"),
                            "application/vnd.Openxmlformats-officedocument.wordProcessingml.Settings+xml");
            expectedValues
                    .Add(PackagingURIHelper.CreatePartName("/word/styles.xml"),
                            "application/vnd.Openxmlformats-officedocument.wordProcessingml.styles+xml");
            expectedValues.Add(PackagingURIHelper
                    .CreatePartName("/word/theme/theme1.xml"),
                    "application/vnd.Openxmlformats-officedocument.theme+xml");
            expectedValues
                    .Add(
                            PackagingURIHelper
                                    .CreatePartName("/word/webSettings.xml"),
                            "application/vnd.Openxmlformats-officedocument.wordProcessingml.webSettings+xml");
        }

        /**
         * List all parts of a namespace.
         */
        [TestMethod]
        public void TestListParts1()
        {
            Stream is1 = OpenXml4NetTestDataSamples.OpenSampleStream("sample.docx");

            OPCPackage p;
            p = OPCPackage.Open(is1);

            foreach (PackagePart part in p.GetParts())
            {
                values.Add(part.PartName, part.ContentType);
                logger.Log(POILogger.DEBUG, part.PartName);
            }

            // Compare expected values with values return by the namespace
            foreach (PackagePartName partName in expectedValues.Keys)
            {
                Assert.IsNotNull(values[partName]);
                Assert.AreEqual(expectedValues[partName], values[partName]);
            }
        }
    }
}



