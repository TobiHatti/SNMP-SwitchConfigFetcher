using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Analyser
{
    public class SNMPResultSet
    {
        public string OID { get; private set; } = "";
        public string DataType { get; private set; } = "";
        public string Value { get; private set; } = "";

        public SNMPResultSet(string pOID, string pDataType, string pValue)
        {
            OID = pOID;
            DataType = pDataType;
            Value = pValue;
        }

        public override string ToString()
        {
            return Value;
        }
    }


    public class SNMP
    {
        public IpAddress AgentIP { get; private set; } = new IpAddress("127.0.0.1");
        public string CommunityName { get; private set; } = "public";
        public int Port { get; private set; } = 161;

        public SNMP(IpAddress pIPAddress, string pCommunity, int pPort)
        {
            AgentIP = pIPAddress;
            CommunityName = pCommunity;
            Port = pPort;
        }

        public SNMPResultSet Get(string pOID)
        {
            SNMPResultSet snmpResult = null;

            // Define agent parameters class
            AgentParameters param = new AgentParameters(new OctetString(CommunityName));

            // Set SNMP version to 1 (or 2)
            param.Version = SnmpVersion.Ver1;

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)AgentIP, 161, 2000, 1);

            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(pOID);

            // Make SNMP request
            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus,
                        result.Pdu.ErrorIndex);
                }
                else
                {
                    // Reply variables are returned in the same order as they were added
                    //  to the VbList

                    snmpResult = new SNMPResultSet(result.Pdu.VbList[0].Oid.ToString(), SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type), result.Pdu.VbList[0].Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }
            target.Close();

            return snmpResult;
        }


        public SNMPResultSet[] Walk(string pOID)
        {
            List<SNMPResultSet> snmpResults = new List<SNMPResultSet>();

            // Define agent parameters class
            AgentParameters param = new AgentParameters(new OctetString(CommunityName));
            // Set SNMP version to 2 (GET-BULK only works with SNMP ver 2 and 3)
            param.Version = SnmpVersion.Ver2;

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)AgentIP, 161, 2000, 1);

            // Define Oid that is the root of the MIB
            //  tree you wish to retrieve
            Oid rootOid = new Oid(pOID); // ifDescr

            // This Oid represents last Oid returned by
            //  the SNMP agent
            Oid lastOid = (Oid)rootOid.Clone();

            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.GetBulk);

            // In this example, set NonRepeaters value to 0
            pdu.NonRepeaters = 0;
            // MaxRepetitions tells the agent how many Oid/Value pairs to return
            // in the response.
            pdu.MaxRepetitions = 5;

            // Loop through results
            while (lastOid != null)
            {
                // When Pdu class is first constructed, RequestId is set to 0
                // and during encoding id will be set to the random value
                // for subsequent requests, id will be set to a value that
                // needs to be incremented to have unique request ids for each
                // packet
                if (pdu.RequestId != 0)
                {
                    pdu.RequestId += 1;
                }
                // Clear Oids from the Pdu class.
                pdu.VbList.Clear();
                // Initialize request PDU with the last retrieved Oid
                pdu.VbList.Add(lastOid);
                // Make SNMP request
                SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);
                // You should catch exceptions in the Request if using in real application.

                // If result is null then agent didn't reply or we couldn't parse the reply.
                if (result != null)
                {
                    // ErrorStatus other then 0 is an error returned by 
                    // the Agent - see SnmpConstants for error definitions
                    if (result.Pdu.ErrorStatus != 0)
                    {
                        // agent reported an error with the request
                        Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                            result.Pdu.ErrorStatus,
                            result.Pdu.ErrorIndex);
                        lastOid = null;
                        break;
                    }
                    else
                    {
                        // Walk through returned variable bindings
                        foreach (Vb v in result.Pdu.VbList)
                        {
                            // Check that retrieved Oid is "child" of the root OID
                            if (rootOid.IsRootOf(v.Oid))
                            {
                                snmpResults.Add(new SNMPResultSet(v.Oid.ToString(), SnmpConstants.GetTypeName(v.Value.Type), v.Value.ToString()));

                                if (v.Value.Type == SnmpConstants.SMI_ENDOFMIBVIEW)
                                    lastOid = null;
                                else
                                    lastOid = v.Oid;
                            }
                            else
                            {
                                // we have reached the end of the requested
                                // MIB tree. Set lastOid to null and exit loop
                                lastOid = null;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No response received from SNMP agent.");
                }
            }
            target.Close();

            return snmpResults.ToArray();
        }
    }
}
