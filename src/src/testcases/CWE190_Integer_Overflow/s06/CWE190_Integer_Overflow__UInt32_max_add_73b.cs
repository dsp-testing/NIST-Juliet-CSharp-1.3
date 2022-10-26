/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt32_max_add_73b.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-73b.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for uint
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Collections.Generic;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt32_max_add_73b
{
#if (!OMITBAD)
    public static void BadSink(LinkedList<uint> dataLinkedList )
    {
        uint data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: if data == uint.MaxValue, this will overflow */
        uint result = (uint)(data + 1);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(LinkedList<uint> dataLinkedList )
    {
        uint data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: if data == uint.MaxValue, this will overflow */
        uint result = (uint)(data + 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(LinkedList<uint> dataLinkedList )
    {
        uint data = dataLinkedList.Last.Value;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data < uint.MaxValue)
        {
            uint result = (uint)(data + 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform addition.");
        }
    }
#endif
}
}