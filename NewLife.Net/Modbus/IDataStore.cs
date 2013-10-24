﻿using System;

namespace NewLife.Net.Modbus
{
    /// <summary>数据存储接口</summary>
    public interface IDataStore
    {
        /// <summary>离散量输入</summary>
        IBitStore Inputs { get; }

        /// <summary>线圈</summary>
        IBitStore Coils { get; }

        /// <summary>输入寄存器</summary>
        IWordStore InputRegisters { get; }

        /// <summary>保持寄存器</summary>
        IWordStore HoldingRegisters { get; }
    }

    /// <summary>写入线圈</summary>
    /// <param name="i"></param>
    /// <param name="value">数值</param>
    public delegate void WriteCoilHandler(Int32 i, Boolean value);

    /// <summary>写入寄存器</summary>
    /// <param name="i"></param>
    /// <param name="value">数值</param>
    public delegate void WriteRegisterHandler(Int32 i, Int32 value);

    /// <summary>位存储接口</summary>
    public interface IBitStore
    {
        /// <summary>数量</summary>
        /// <returns></returns>
        Int32 Count { get; }

        /// <summary>索引器，不影响<see cref="OnWrite"/>事件</summary>
        /// <param name="i"></param>
        /// <returns></returns>
        Boolean this[Int32 i] { get; set; }

        /// <summary>读取状态</summary>
        /// <param name="i"></param>
        /// <returns></returns>
        Boolean Read(Int32 i);

        /// <summary>写入状态</summary>
        /// <param name="i"></param>
        /// <param name="flag"></param>
        void Write(Int32 i, Boolean flag);

        /// <summary>写入线圈</summary>
        event WriteCoilHandler OnWrite;
    }

    /// <summary>字存储接口</summary>
    public interface IWordStore
    {
        /// <summary>寄存器数</summary>
        /// <returns></returns>
        Int32 Count { get; }

        /// <summary>索引器，不影响<see cref="OnWrite"/>事件</summary>
        /// <param name="i"></param>
        /// <returns></returns>
        UInt16 this[Int32 i] { get; set; }

        /// <summary>读取</summary>
        /// <param name="i"></param>
        /// <returns></returns>
        UInt16 Read(Int32 i);

        /// <summary>写入</summary>
        /// <param name="i"></param>
        /// <param name="value">数值</param>
        void Write(Int32 i, UInt16 value);

        /// <summary>写入寄存器</summary>
        event WriteRegisterHandler OnWrite;
    }
}