﻿using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace AElf.Kernel.Types.Tests
{
    public class BloomTests
    {
        [Fact]
        public void Length_Test()
        {
            var bloom = new Bloom();
            Assert.Equal(256, bloom.Data.Length);
            
            var bloomData = Guid.NewGuid().ToByteArray();
            Should.Throw<InvalidOperationException>(
                () =>
                {
                    new Bloom(bloomData);
                });
        }

        [Fact]
        public void AddHashAddValue_Test()
        {
            var empty = BytesValue.Parser.ParseFrom(ByteString.Empty);
            var elf = new StringValue()
            {
                Value = "ELF"
            }; // Serialized: 0a03454c46
            // sha256 of empty string: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
            // sha256 of 0a03454c46: 782330156f8c9403758ed30270a3e2d59e50b8f04c6779d819b72eee02addb13
            var expected = string.Concat(
                "0000000000000000000000000000100000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000040000000000000000",
                "0000000000000000000100000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000800200000"
            );
            var bloom = new Bloom();
            bloom.AddSha256Hash(
                ByteArrayHelper.HexStringToByteArray("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"));
            bloom.AddSha256Hash(
                ByteArrayHelper.HexStringToByteArray("782330156f8c9403758ed30270a3e2d59e50b8f04c6779d819b72eee02addb13"));
            Assert.Equal(expected, bloom.Data.ToHex().Replace("0x", ""));

            // add value
            var bloom1 = new Bloom();
            bloom1.AddValue(empty);
            bloom1.AddValue(elf);
            Assert.Equal(expected, bloom1.Data.ToHex().Replace("0x", ""));

            // Take only 12 characters (2 * 3 = 6 bytes)
            var bloom2 = new Bloom();
            var fiftyTwoZeros = string.Join("", Enumerable.Repeat("0", 52));

            // Too short
            Assert.ThrowsAny<Exception>(() => bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("e3b0c44298fc")));
            Assert.ThrowsAny<Exception>(() => bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("782330156f8c")));

            // Too long

            Assert.ThrowsAny<Exception>(() =>
                bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("e3b0c44298fc" + "00" + fiftyTwoZeros)));
            Assert.ThrowsAny<Exception>(() =>
                bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("782330156f8c" + "00" + fiftyTwoZeros)));

            // Right size
            bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("e3b0c44298fc" + fiftyTwoZeros));
            bloom2.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("782330156f8c" + fiftyTwoZeros));
            Assert.Equal(expected, bloom2.Data.ToHex().Replace("0x", ""));

            // Incorrect value
            var bloom3 = new Bloom();
            bloom3.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("e3b0c44298f0" + fiftyTwoZeros));
            bloom3.AddSha256Hash(ByteArrayHelper.HexStringToByteArray("782330156f80" + fiftyTwoZeros));
            Assert.NotEqual(expected, bloom3.Data.ToHex().Replace("0x", ""));
        }

        [Fact]
        public void MultiMerge_Test()
        {
            var a = ByteArrayHelper.HexStringToByteArray(string.Concat(
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000"
            ));
            
            var b = ByteArrayHelper.HexStringToByteArray(string.Concat(
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000",
                "0100000000000000000000000000000000000000000000000000000000000000"
            ));
            
            var c = ByteArrayHelper.HexStringToByteArray(string.Concat(
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000",
                "1100000000000000000000000000000000000000000000000000000000000000"
            ));

            var res = Bloom.AndMultipleBloomBytes(new List<byte[]>(){a, b});
            Assert.Equal(c, res);
        }

        [Fact]
        public void IsIn_Test()
        {
            var target = new Bloom(ByteArrayHelper.HexStringToByteArray(string.Concat(
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000"
            )));
            var source = new Bloom(ByteArrayHelper.HexStringToByteArray(string.Concat(
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000"
            )));
            Assert.True(source.IsIn(target));
            
            var wrongSource = new Bloom(ByteArrayHelper.HexStringToByteArray(string.Concat(
                "1110000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000"
            )));
            
            Assert.False(wrongSource.IsIn(target));
        }
    }
}