using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetControllerCore.OpenFlow
{
    /// <summary>
    /// Net Controllers OpenFlow Definitions
    /// </summary>
    public class OpenFlowDefinitions
    {
        public const int OfpVersion = 0x01;
        public const int OfpMaxTableNameLen = 32;
        public const int OfpMaxPortNameLen = 16;

        public const int OfpTcpPort = 6633;
        public const int OfpSslPort = 6633;

        public const int OfpEthAlen = 6;          /* Bytes in an Ethernet address. */

        /* The VLAN id is 12 bits, so we can use the entire 16 bits to indicate
         * special conditions.  All ones is used to match that no VLAN id was
         * set. */
        public const int OfpVlanNone = 0xffff;

        public const int OfpDefaultMissSendLen = 128;

        /* Values below this cutoff are 802.3 packets and the two bytes
         * following MAC addresses are used as a frame length.  Otherwise, the
         * two bytes are used as the Ethernet type.
         */
        public const int OfpDlTypeEth2Cutoff = 0x0600;

        /* Value of dl_type to indicate that the frame does not include an
         * Ethernet type.
         */
        public const int OfpDlTypeNotEthType = 0x05ff;

        /* Value used in "idle_timeout" and "hard_timeout" to indicate that the entry
         * is permanent. */
        public const int OfpFlowPermanent = 0;

        /* By default, choose a priority in the middle. */
        public const int OfpDefaultPriority = 0x8000;

        public const int DescStrLen = 256;
        public const int SerialNumLen = 32;

        /* All ones is used to indicate all queues in a port (for stats retrieval). */
        public const uint OfpqAll = 0xffffffff;

        /* Min rate > 1000 means not configured. */
        public const int OfpqMinRateUncfg = 0xffff;

        public const int OfpActionDlAddrBytes = 16;
        public const int OfpActionEnqueueBytes = 16;
        public const int OfpActionHeaderBytes = 8;
        public const int OfpActionNwAddrBytes = 8;
        public const int OfpActionNwTosBytes = 8;
        public const int OfpActionOutputBytes = 8;
        public const int OfpActionTpPortBytes = 8;
        public const int OfpActionVendorHeaderBytes = 8;
        public const int OfpActionVlanPcpBytes = 8;
        public const int OfpActionVlanVidBytes = 8;
        public const int OfpAggregateStatsReplyBytes = 24;
        public const int OfpAggregateStatsRequestBytes = 44;
        public const int OfpDescStatsBytes = 1056;
        public const int OfpErrorMsgBytes = 12;
        public const int OfpFeaturesRequestBytes = 8;
        public const int OfpFeaturesReplyBytes = 32;
        public const int OfpFlowModBytes = 72;
        public const int OfpFlowRemovedBytes = 88;
        public const int OfpFlowStatsBytes = 88;
        public const int OfpFlowStatsRequestBytes = 44;
        public const int OfpHeaderBytes = 8;
        public const int OfpHelloBytes = 8;
        public const int OfpMatchBytes = 40;
        public const int OfpPacketInBytes = 18;
        public const int OfpPacketOutBytes = 16;
        public const int OfpPacketQueueBytes = 8;
        public const int OfpPhyPortBytes = 48;
        public const int OfpPortModBytes = 32;
        public const int OfpPortStatsBytes = 104;
        public const int OfpPortStatsRequestBytes = 8;
        public const int OfpPortStatusBytes = 64;
        public const int OfpQueueGetConfigReplyBytes = 16;
        public const int OfpQueueGetConfigRequestBytes = 12;
        public const int OfpQueuePropHeaderBytes = 8;
        public const int OfpQueuePropMinRateBytes = 16;
        public const int OfpQueueStatsBytes = 32;
        public const int OfpQueueStatsRequestBytes = 8;
        public const int OfpStatsReplyBytes = 12;
        public const int OfpStatsRequestBytes = 12;
        public const int OfpSwitchConfigBytes = 12;
        public const int OfpTableStatsBytes = 64;
        public const int OfpVendorHeaderBytes = 12;

        public const int OfpMaxXid = 0x7FFFFFFF;
        public const uint OfpMaxLen = uint.MaxValue;
        public const int OfpMaxMsgBytes = 64 * 1024;
        public const uint OfpMaxActionBytes = uint.MaxValue;
        public const int OfpMaxActionCount = 64;
        public const int OfpMaxPacketBytes = 9 * 1024 + 128;
        public const int OfpMaxQueues = 1024;
        public const int OfpMaxQueuePropBytes = 64;
        public const int OfpMaxQueuePropCount = 64;
        public const int OfpMaxStatsPerReply = 64;

        public bool SendFlowRemoved = true;

        /** Default idle timeout for flows
         */
        public bool DefaultFlowTimeout { get; set; }

        /* Flow wildcards. */
        public enum OfpFlowWildcards
        {
            OfpfwInPort  = 1 << 0,  /* Switch input port. */
            OfpfwDlVlan  = 1 << 1,  /* VLAN id. */
            OfpfwDlSrc   = 1 << 2,  /* Ethernet source address. */
            OfpfwDlDst   = 1 << 3,  /* Ethernet destination address. */
            OfpfwDlType  = 1 << 4,  /* Ethernet frame type. */
            OfpfwNwProto = 1 << 5,  /* IP protocol. */
            OfpfwTpSrc   = 1 << 6,  /* TCP/UDP source port. */
            OfpfwTpDst   = 1 << 7,  /* TCP/UDP destination port. */

            /* IP source address wildcard bit count.  0 is exact match, 1 ignores the
             * LSB, 2 ignores the 2 least-significant bits, ..., 32 and higher wildcard
             * the entire field.  This is the *opposite* of the usual convention where
             * e.g. /24 indicates that 8 bits (not 24 bits) are wildcarded. */
            OfpfwNwSrcShift = 8,
            OfpfwNwSrcBits = 6,
            OfpfwNwSrcMask = ((1 << OfpfwNwSrcBits) - 1) << OfpfwNwSrcShift,
            OfpfwNwSrcAll = 32 << OfpfwNwSrcShift,

            /* IP destination address wildcard bit count.  Same format as source. */
            OfpfwNwDstShift = 14,
            OfpfwNwDstBits = 6,
            OfpfwNwDstMask = ((1 << OfpfwNwDstBits) - 1) << OfpfwNwDstShift,
            OfpfwNwDstAll = 32 << OfpfwNwDstShift,

            OfpfwDlVlanPcp = 1 << 20,  /* VLAN priority. */
            OfpfwNwTos = 1 << 21,  /* IP ToS (DSCP field, 6 bits). */

            /* Wildcard all fields. */
            OfpfwAll = ((1 << 22) - 1)
        };

        /* The wildcards for ICMP type and code fields use the transport source
         * and destination port fields, respectively. */
        public static uint OfpfwIcmpType { get; set; }

        public static uint OfpfwIcmpCode { get; set; }

    }
}
