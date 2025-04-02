
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is1 distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */



namespace TestCases.HSSF.Record.Chart
{
    using System;
    using NPOI.HSSF.Record;
    using NPOI.HSSF.Record.Chart;
    using NUnit.Framework;using NUnit.Framework.Legacy;

    /**
     * Tests the serialization and deserialization of the AxisUsedRecord
     * class works correctly.  Test data taken directly from a real
     * Excel file.
     *

     * @author Glen Stampoultzis (glens at apache.org)
     */
    [TestFixture]
    public class TestAxisUsedRecord
    {
        byte[] data = new byte[] {
        (byte)0x01,(byte)0x00,
    };
        
        public TestAxisUsedRecord()
        {

        }
        [Test]
        public void TestLoad()
        {
            AxisUsedRecord record = new AxisUsedRecord(TestcaseRecordInputStream.Create((short)0x1046, data));
            ClassicAssert.AreEqual(1, record.NumAxis);
            ClassicAssert.AreEqual(6, record.RecordSize);
        }
        [Test]
        public void TestStore()
        {
            AxisUsedRecord record = new AxisUsedRecord();
            record.NumAxis = ((short)1);


            byte[] recordBytes = record.Serialize();
            ClassicAssert.AreEqual(recordBytes.Length - 4, data.Length);
            for (int i = 0; i < data.Length; i++)
                ClassicAssert.AreEqual(data[i], recordBytes[i + 4], "At offset " + i);
        }
    }
}
