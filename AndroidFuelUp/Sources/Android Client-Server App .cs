using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using NetworkInterface = Java.Net.NetworkInterface;

namespace AndroidFuelUp.Sources
{
    public partial class CommsInterface
    {
        /// UnicastIPAddressInformation.IPv4Mask is not implemented in Xamarin. This method sits in a partial class definition
        protected static IPAddress GetSubnetMask(UnicastIPAddressInformation ip)
        {
            // short circuit on null ip.
            if (ip == null)
                return null;

            // TODO: Use native java network library rather than incomplete mono/.NET implementation:
            // Move this into CommsInterface.cs and call once rather than iterating all adapters for each GetSubnetMaskCall.
            var interfaces = NetworkInterface.NetworkInterfaces.GetEnumerable<NetworkInterface>().ToList();
            var interfacesWithIPv4Addresses = interfaces
                                                .Where(ni => ni.InterfaceAddresses != null)
                                                .SelectMany(ni => ni.InterfaceAddresses
                                                                        .Where(a => a.Address != null && a.Address.HostAddress != null)
                                                                        .Select(a => new { NativeInterface = ni, Address = a }))
                                                .ToList();

            var ipAddress = ip.Address.ToString();

            // match the droid interface with the NetworkInterface interface on the IpAddress string
            var match = interfacesWithIPv4Addresses.FirstOrDefault(ni => ni.Address.Address.HostAddress == ipAddress);

            // no match, no good
            if (match == null)
                return null;

            // use the network prefix length to calculate the subnet address
            var networkPrefixLength = match.Address.NetworkPrefixLength;
            var netMask = AndroidNetworkExtensions.GetSubnetAddress(ipAddress, networkPrefixLength);

            return IPAddress.Parse(netMask);
        }
    }

    /// Helper methods required for the conversion of platform-specific network items to the abstracted versions.
    public static class AndroidNetworkExtensions
    {
        /// Allows a Java.Util.IEnumeration to be enumerated as an IEnumerable.
        public static IEnumerable<T> GetEnumerable<T>(this Java.Util.IEnumeration enumeration) where T : class
        {
            while (enumeration.HasMoreElements)
                yield return enumeration.NextElement() as T;
        }

        /// Calculates the subnet address for an ip address given its prefix link.
        /// Returns the ip as a string in dotted quad notation.
        public static string GetSubnetAddress(string ipAddress, int prefixLength)
        {
            var maskBits = Enumerable.Range(0, 32)
                .Select(i => i < prefixLength)
                .ToArray();

            return maskBits
                .ToBytes()
                .ToDottedQuadNotation();
        }

        /// Converts an array of bools to an array of bytes, 8 bits per byte.
        /// Expects most significant bit first.
        public static byte[] ToBytes(this bool[] bits)
        {
            var theseBits = bits.Reverse().ToArray();
            var ba = new BitArray(theseBits);

            var bytes = new byte[theseBits.Length / 8];
            ((ICollection)ba).CopyTo(bytes, 0);

            bytes = bytes.Reverse().ToArray();

            return bytes;
        }

        /// Converts dotted quad representation of an ip address into a byte array.
        public static byte[] GetAddressBytes(string ipAddress)
        {
            var ipBytes = new byte[4];

            var parsesResults =
                ipAddress.Split('.')
                    .Select((p, i) => byte.TryParse(p, out ipBytes[i]))
                    .ToList();

            var valid = (parsesResults.Count == 4 && parsesResults.All(r => r));

            if (valid)
                return ipBytes;
            else
                throw new InvalidOperationException("The string provided did not appear to be a valid IP Address");
        }

        /// Converts a byte array into dotted quad representation.
        public static string ToDottedQuadNotation(this byte[] bytes)
        {
            if (bytes.Length % 4 != 0)
                throw new InvalidOperationException("Byte array has an invalid byte count for dotted quad conversion");

            return String.Join(".", bytes.Select(b => ((int)b).ToString()));
        }
    }
}