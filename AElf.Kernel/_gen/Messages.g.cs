// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: messages.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.Kernel {

  /// <summary>Holder for reflection information generated from messages.proto</summary>
  public static partial class MessagesReflection {

    #region Descriptor
    /// <summary>File descriptor for messages.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MessagesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5tZXNzYWdlcy5wcm90byJuCgtUcmFuc2FjdGlvbhITCgRGcm9tGAEgASgL",
            "MgUuSGFzaBIRCgJUbxgCIAEoCzIFLkhhc2gSEwoLSW5jcmVtZW50SWQYAyAB",
            "KAQSEgoKTWV0aG9kTmFtZRgEIAEoCRIOCgZQYXJhbXMYBSABKAwiFQoESGFz",
            "aBINCgVWYWx1ZRgBIAEoDCI8CgtCbG9ja0hlYWRlchIPCgdWZXJzaW9uGAEg",
            "ASgFEhwKDVBlcnZpb3VzQmxvY2sYAiABKAsyBS5IYXNoIkQKCUJsb2NrQm9k",
            "eRIaCgtCbG9ja0hlYWRlchgBIAEoCzIFLkhhc2gSGwoMVHJhbnNhY3Rpb25z",
            "GAIgAygLMgUuSGFzaCI/CgVCbG9jaxIcCgZIZWFkZXIYASABKAsyDC5CbG9j",
            "a0hlYWRlchIYCgRCb2R5GAIgASgLMgouQmxvY2tCb2R5Qg6qAgtBRWxmLktl",
            "cm5lbGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Kernel.Transaction), global::AElf.Kernel.Transaction.Parser, new[]{ "From", "To", "IncrementId", "MethodName", "Params" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Kernel.Hash), global::AElf.Kernel.Hash.Parser, new[]{ "Value" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Kernel.BlockHeader), global::AElf.Kernel.BlockHeader.Parser, new[]{ "Version", "PerviousBlock" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Kernel.BlockBody), global::AElf.Kernel.BlockBody.Parser, new[]{ "BlockHeader", "Transactions" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Kernel.Block), global::AElf.Kernel.Block.Parser, new[]{ "Header", "Body" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Transaction : pb::IMessage<Transaction> {
    private static readonly pb::MessageParser<Transaction> _parser = new pb::MessageParser<Transaction>(() => new Transaction());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Transaction> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Kernel.MessagesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Transaction() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Transaction(Transaction other) : this() {
      From = other.from_ != null ? other.From.Clone() : null;
      To = other.to_ != null ? other.To.Clone() : null;
      incrementId_ = other.incrementId_;
      methodName_ = other.methodName_;
      params_ = other.params_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Transaction Clone() {
      return new Transaction(this);
    }

    /// <summary>Field number for the "From" field.</summary>
    public const int FromFieldNumber = 1;
    private global::AElf.Kernel.Hash from_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.Hash From {
      get { return from_; }
      set {
        from_ = value;
      }
    }

    /// <summary>Field number for the "To" field.</summary>
    public const int ToFieldNumber = 2;
    private global::AElf.Kernel.Hash to_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.Hash To {
      get { return to_; }
      set {
        to_ = value;
      }
    }

    /// <summary>Field number for the "IncrementId" field.</summary>
    public const int IncrementIdFieldNumber = 3;
    private ulong incrementId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong IncrementId {
      get { return incrementId_; }
      set {
        incrementId_ = value;
      }
    }

    /// <summary>Field number for the "MethodName" field.</summary>
    public const int MethodNameFieldNumber = 4;
    private string methodName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MethodName {
      get { return methodName_; }
      set {
        methodName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Params" field.</summary>
    public const int ParamsFieldNumber = 5;
    private pb::ByteString params_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Params {
      get { return params_; }
      set {
        params_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Transaction);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Transaction other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(From, other.From)) return false;
      if (!object.Equals(To, other.To)) return false;
      if (IncrementId != other.IncrementId) return false;
      if (MethodName != other.MethodName) return false;
      if (Params != other.Params) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (from_ != null) hash ^= From.GetHashCode();
      if (to_ != null) hash ^= To.GetHashCode();
      if (IncrementId != 0UL) hash ^= IncrementId.GetHashCode();
      if (MethodName.Length != 0) hash ^= MethodName.GetHashCode();
      if (Params.Length != 0) hash ^= Params.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (from_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(From);
      }
      if (to_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(To);
      }
      if (IncrementId != 0UL) {
        output.WriteRawTag(24);
        output.WriteUInt64(IncrementId);
      }
      if (MethodName.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(MethodName);
      }
      if (Params.Length != 0) {
        output.WriteRawTag(42);
        output.WriteBytes(Params);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (from_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(From);
      }
      if (to_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(To);
      }
      if (IncrementId != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(IncrementId);
      }
      if (MethodName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MethodName);
      }
      if (Params.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Params);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Transaction other) {
      if (other == null) {
        return;
      }
      if (other.from_ != null) {
        if (from_ == null) {
          from_ = new global::AElf.Kernel.Hash();
        }
        From.MergeFrom(other.From);
      }
      if (other.to_ != null) {
        if (to_ == null) {
          to_ = new global::AElf.Kernel.Hash();
        }
        To.MergeFrom(other.To);
      }
      if (other.IncrementId != 0UL) {
        IncrementId = other.IncrementId;
      }
      if (other.MethodName.Length != 0) {
        MethodName = other.MethodName;
      }
      if (other.Params.Length != 0) {
        Params = other.Params;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (from_ == null) {
              from_ = new global::AElf.Kernel.Hash();
            }
            input.ReadMessage(from_);
            break;
          }
          case 18: {
            if (to_ == null) {
              to_ = new global::AElf.Kernel.Hash();
            }
            input.ReadMessage(to_);
            break;
          }
          case 24: {
            IncrementId = input.ReadUInt64();
            break;
          }
          case 34: {
            MethodName = input.ReadString();
            break;
          }
          case 42: {
            Params = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Hash : pb::IMessage<Hash> {
    private static readonly pb::MessageParser<Hash> _parser = new pb::MessageParser<Hash>(() => new Hash());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Hash> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Kernel.MessagesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hash() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hash(Hash other) : this() {
      value_ = other.value_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Hash Clone() {
      return new Hash(this);
    }

    /// <summary>Field number for the "Value" field.</summary>
    public const int ValueFieldNumber = 1;
    private pb::ByteString value_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Value {
      get { return value_; }
      set {
        value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Hash);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Hash other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Value != other.Value) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Value.Length != 0) hash ^= Value.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Value.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(Value);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Value.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Value);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Hash other) {
      if (other == null) {
        return;
      }
      if (other.Value.Length != 0) {
        Value = other.Value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Value = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class BlockHeader : pb::IMessage<BlockHeader> {
    private static readonly pb::MessageParser<BlockHeader> _parser = new pb::MessageParser<BlockHeader>(() => new BlockHeader());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BlockHeader> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Kernel.MessagesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockHeader() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockHeader(BlockHeader other) : this() {
      version_ = other.version_;
      PerviousBlock = other.perviousBlock_ != null ? other.PerviousBlock.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockHeader Clone() {
      return new BlockHeader(this);
    }

    /// <summary>Field number for the "Version" field.</summary>
    public const int VersionFieldNumber = 1;
    private int version_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Version {
      get { return version_; }
      set {
        version_ = value;
      }
    }

    /// <summary>Field number for the "PerviousBlock" field.</summary>
    public const int PerviousBlockFieldNumber = 2;
    private global::AElf.Kernel.Hash perviousBlock_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.Hash PerviousBlock {
      get { return perviousBlock_; }
      set {
        perviousBlock_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BlockHeader);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BlockHeader other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Version != other.Version) return false;
      if (!object.Equals(PerviousBlock, other.PerviousBlock)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Version != 0) hash ^= Version.GetHashCode();
      if (perviousBlock_ != null) hash ^= PerviousBlock.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Version != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Version);
      }
      if (perviousBlock_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(PerviousBlock);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Version != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Version);
      }
      if (perviousBlock_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PerviousBlock);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BlockHeader other) {
      if (other == null) {
        return;
      }
      if (other.Version != 0) {
        Version = other.Version;
      }
      if (other.perviousBlock_ != null) {
        if (perviousBlock_ == null) {
          perviousBlock_ = new global::AElf.Kernel.Hash();
        }
        PerviousBlock.MergeFrom(other.PerviousBlock);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Version = input.ReadInt32();
            break;
          }
          case 18: {
            if (perviousBlock_ == null) {
              perviousBlock_ = new global::AElf.Kernel.Hash();
            }
            input.ReadMessage(perviousBlock_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class BlockBody : pb::IMessage<BlockBody> {
    private static readonly pb::MessageParser<BlockBody> _parser = new pb::MessageParser<BlockBody>(() => new BlockBody());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BlockBody> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Kernel.MessagesReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockBody() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockBody(BlockBody other) : this() {
      BlockHeader = other.blockHeader_ != null ? other.BlockHeader.Clone() : null;
      transactions_ = other.transactions_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockBody Clone() {
      return new BlockBody(this);
    }

    /// <summary>Field number for the "BlockHeader" field.</summary>
    public const int BlockHeaderFieldNumber = 1;
    private global::AElf.Kernel.Hash blockHeader_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.Hash BlockHeader {
      get { return blockHeader_; }
      set {
        blockHeader_ = value;
      }
    }

    /// <summary>Field number for the "Transactions" field.</summary>
    public const int TransactionsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::AElf.Kernel.Hash> _repeated_transactions_codec
        = pb::FieldCodec.ForMessage(18, global::AElf.Kernel.Hash.Parser);
    private readonly pbc::RepeatedField<global::AElf.Kernel.Hash> transactions_ = new pbc::RepeatedField<global::AElf.Kernel.Hash>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::AElf.Kernel.Hash> Transactions {
      get { return transactions_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BlockBody);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BlockBody other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(BlockHeader, other.BlockHeader)) return false;
      if(!transactions_.Equals(other.transactions_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (blockHeader_ != null) hash ^= BlockHeader.GetHashCode();
      hash ^= transactions_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (blockHeader_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(BlockHeader);
      }
      transactions_.WriteTo(output, _repeated_transactions_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (blockHeader_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(BlockHeader);
      }
      size += transactions_.CalculateSize(_repeated_transactions_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BlockBody other) {
      if (other == null) {
        return;
      }
      if (other.blockHeader_ != null) {
        if (blockHeader_ == null) {
          blockHeader_ = new global::AElf.Kernel.Hash();
        }
        BlockHeader.MergeFrom(other.BlockHeader);
      }
      transactions_.Add(other.transactions_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (blockHeader_ == null) {
              blockHeader_ = new global::AElf.Kernel.Hash();
            }
            input.ReadMessage(blockHeader_);
            break;
          }
          case 18: {
            transactions_.AddEntriesFrom(input, _repeated_transactions_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class Block : pb::IMessage<Block> {
    private static readonly pb::MessageParser<Block> _parser = new pb::MessageParser<Block>(() => new Block());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Block> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Kernel.MessagesReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block(Block other) : this() {
      Header = other.header_ != null ? other.Header.Clone() : null;
      Body = other.body_ != null ? other.Body.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block Clone() {
      return new Block(this);
    }

    /// <summary>Field number for the "Header" field.</summary>
    public const int HeaderFieldNumber = 1;
    private global::AElf.Kernel.BlockHeader header_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.BlockHeader Header {
      get { return header_; }
      set {
        header_ = value;
      }
    }

    /// <summary>Field number for the "Body" field.</summary>
    public const int BodyFieldNumber = 2;
    private global::AElf.Kernel.BlockBody body_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.Kernel.BlockBody Body {
      get { return body_; }
      set {
        body_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Block);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Block other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Header, other.Header)) return false;
      if (!object.Equals(Body, other.Body)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (header_ != null) hash ^= Header.GetHashCode();
      if (body_ != null) hash ^= Body.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (header_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Header);
      }
      if (body_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Body);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (header_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Header);
      }
      if (body_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Body);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Block other) {
      if (other == null) {
        return;
      }
      if (other.header_ != null) {
        if (header_ == null) {
          header_ = new global::AElf.Kernel.BlockHeader();
        }
        Header.MergeFrom(other.Header);
      }
      if (other.body_ != null) {
        if (body_ == null) {
          body_ = new global::AElf.Kernel.BlockBody();
        }
        Body.MergeFrom(other.Body);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (header_ == null) {
              header_ = new global::AElf.Kernel.BlockHeader();
            }
            input.ReadMessage(header_);
            break;
          }
          case 18: {
            if (body_ == null) {
              body_ = new global::AElf.Kernel.BlockBody();
            }
            input.ReadMessage(body_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
